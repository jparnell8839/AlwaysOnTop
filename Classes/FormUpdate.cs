using System;
using System.ComponentModel;
using System.Windows.Forms;
using Octokit;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;
using Microsoft.Win32;

namespace AlwaysOnTop.Classes
{
    public partial class FormUpdate : Form
    {
        private Release release;

        public FormUpdate()
        {
            InitializeComponent();
        }

        public FormUpdate(Release zrelease)
        {
            InitializeComponent();
            release = zrelease;
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            btnUpdate.Hide();
            llblHelp.Hide();
            lblDestination.Text = Path.GetTempPath().ToString();
            lblFileName.Text = release.Assets[0].Name;
            startDownload(release.Assets[0].BrowserDownloadUrl,release.Assets[0].Name);
        }

        private void startDownload(string url, string fileName)
        {
            var thread = new Thread(() => {
                var client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), Path.GetTempPath().ToString() + fileName);
            });
            lblStatus.Text = "Downloading...";
            try
            {
                var now = DateTime.Now.ToString();
                using (var rkSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
                {
                    Methods.TryRegString(rkSettings, "Last check for Update", now, true);
                }
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                var bytesIn = double.Parse(e.BytesReceived.ToString());
                var totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                var percentage = bytesIn / totalBytes * 100;
                lblDownloaded.Text = e.BytesReceived.ToString();
                lblDownloadTotal.Text = e.TotalBytesToReceive.ToString();
                pbDownload.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                lblStatus.Text = "Complete";
                btnUpdate.Show();
                llblHelp.Show();

            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@Path.GetTempPath().ToString() + release.Assets[0].Name);
                System.Windows.Forms.Application.Exit();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("There may be a couple reasons why the updater did not work." + Environment.NewLine + Environment.NewLine +
                "Usually this occurs if either GitHub could not be contacted (check internet connection) or" + Environment.NewLine +
                "the %temp% directory could not be written to. If you have AntiVirus, please disable that and try again." + Environment.NewLine + Environment.NewLine +
                "If the problem persists, please file an issue at https://github.com/jparnell8839/AlwaysOnTop/issues",
                "Did your upgrade not work?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
