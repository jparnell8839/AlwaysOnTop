using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using Octokit;
using System.Threading.Tasks;

namespace AlwaysOnTop.Classes
{

	class Methods
	{
		/******** For GetWindowTitle() *********************/
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
		/*********** END ***********************************/

		/********* Setting Windows on Top ******************/

		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

		[DllImport("user32.dll")]
		static extern bool SetWindowText(IntPtr hWnd, string text);

		const UInt32 SW_HIDE = 0;
		const UInt32 SW_SHOWNORMAL = 1;
		const UInt32 SW_NORMAL = 1;
		const UInt32 SW_SHOWMINIMIZED = 2;
		const UInt32 SW_SHOWMAXIMIZED = 3;
		const UInt32 SW_MAXIMIZE = 3;
		const UInt32 SW_SHOWNOACTIVATE = 4;
		const UInt32 SW_SHOW = 5;
		const UInt32 SW_MINIMIZE = 6;
		const UInt32 SW_SHOWMINNOACTIVE = 7;
		const UInt32 SW_SHOWNA = 8;
		const UInt32 SW_RESTORE = 9;
		const int SWP_NOMOVE = 0x0002;
		const int SWP_NOSIZE = 0x0001;
		const int SWP_SHOWWINDOW = 0x0040;
		const int SWP_NOACTIVATE = 0x0010;
		const int HWND_TOPMOST = -1;
		const int HWND_NOTOPMOST = -2;
		/*********** END ***********************************/


		public static async Task<string> GetWindowTitle()
		{
			const int nChars = 256;
			var buff = new StringBuilder(nChars);
			while (true)
			{
				if (GetWindowText(GetForegroundWindow(), buff, nChars) > 0)
				{
					return buff.ToString();
				}

				// Don't need loop to run as fast as it can.
				await Task.Delay(100);
			}
		}

		public static void AoT_on(string title)
		{
			var processes = Process.GetProcesses(".");
			foreach (var process in processes)
			{
				var mWinTitle = process.MainWindowTitle.ToString();
				if (mWinTitle == title)
				{
					var handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
						var newTitle = title + " - AlwaysOnTop";
						SetWindowText(handle, newTitle);
					}
				}
				
			}
		} // AoT_on()

		public static void AoT_off(string title)
		{
			var processes = Process.GetProcesses(".");
			foreach (var process in processes)
			{
				var mWinTitle = process.MainWindowTitle.ToString();
				if ( mWinTitle == title)
				{
					var handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
						var newTitle = title.Substring(0,title.Length - 14);
						SetWindowText(handle, newTitle);
					}
				}
			}
		} // AoT_off()

		public static string TryRegString(RegistryKey rk, string keyName, string value, bool overwrite)
		{
			string temp;

			try
			{
                temp = (string)rk.GetValue(keyName);
			}
			catch
			{
                rk.SetValue(keyName, value, RegistryValueKind.String);
                temp = (string)rk.GetValue(keyName);
			}
			if (overwrite == true)
			{
				if (temp != value)
				{
					rk.SetValue(keyName, value, RegistryValueKind.String);
					temp = (string)rk.GetValue(keyName);
				}
			}

			return temp;
		}

		public static int TryRegInt(RegistryKey rk, string keyName, int value, bool overwrite)
		{
			int temp;

			try
			{
				temp = (int)rk.GetValue(keyName);
			}
			catch
			{
				rk.SetValue(keyName, value, RegistryValueKind.DWord);
				temp = (int)rk.GetValue(keyName);
			}

			if(overwrite == true)
			{
				if (temp != value)
				{
					rk.SetValue(keyName, value, RegistryValueKind.DWord);
					temp = (int)rk.GetValue(keyName);
				}
			}
			
			return temp;
		}

        public static void GetReleases()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("AlwaysOnTop-Updater"));
                var releases = client.Repository.Release.GetAll("jparnell8839", "AlwaysOnTop").Result;
                var latest = releases[0];

	            if (latest.TagName != AlwaysOnTop.version)
                {
                    var downloadUpdate = MessageBox.Show("You have " + AlwaysOnTop.version + " installed." + Environment.NewLine
                        + "The latest release is " + latest.TagName + Environment.NewLine
                        + Environment.NewLine
                        + "Would you like to download the newest update?",
                        "Update Check",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if(downloadUpdate == DialogResult.Yes)
                    {
                        //MessageBox.Show(latest);
                        var update = new FormUpdate(latest);
                        update.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("You are up to date!","Update Check",MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /*public static void GetReleases(int updateFreq, DateTime lastCheck)
        {
            Thread thread = new Thread(() =>
            {
                long wut = new int();
                TimeSpan lol = DateTime.Now - lastCheck;
                wut = long.Parse(lol.ToString("yyyMMddHHmmss"));
                try
                {
                    var client = new GitHubClient(new ProductHeaderValue("AlwaysOnTop-Updater"));
                    var releases = client.Repository.Release.GetAll("jparnell8839", "AlwaysOnTop").Result;
                    Release latest = releases[0];
                    var assets = latest.Assets;


                    if (latest.TagName != AlwaysOnTop.version)
                    {
                        DialogResult downloadUpdate = MessageBox.Show("You have " + AlwaysOnTop.version + " installed." + Environment.NewLine
                            + "The latest release is " + latest.TagName + Environment.NewLine
                            + Environment.NewLine
                            + "Would you like to download the newest update?",
                            "Update Check",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (downloadUpdate == DialogResult.Yes)
                        {
                            //MessageBox.Show(latest);
                            FormUpdate update = new FormUpdate(latest);
                            update.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are up to date!", "Update Check", MessageBoxButtons.OK);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        public static void ThreadComplete(object sender, AsyncCompletedEventArgs e)
        {

        }*/
    }
}
