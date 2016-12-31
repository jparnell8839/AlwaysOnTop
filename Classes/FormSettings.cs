using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlwaysOnTop.Classes
{
	public partial class FormSettings : Form
	{
		
		string AoTPath = Application.ExecutablePath.ToString();
		string RunAtLogin = "Run at Login";
		string UseHotKey = "Use Hot Key";
		string Hotkey = "Hotkey";

		public FormSettings()
		{
			InitializeComponent();
		}

		private void FormSettings_Load(object sender, EventArgs e)
		{
			btnApply.Enabled = false;

			chkTitleContext.Enabled = false;
			chkHotKey.Enabled = false;			
			
			using (RegistryKey rkAoTSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				int f = (int)rkAoTSettings.GetValue(RunAtLogin);
				if (f == 1)
				{
					chkRunAtLogin.Checked = true;
				}
			}

		}

		private void chkRunAtLogin_CheckedChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
			
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			if (chkRunAtLogin.Checked)
			{
				using (RegistryKey rkRunAtLogin = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
				{
					rkRunAtLogin.SetValue("AlwaysOnTop", AoTPath);
				}
				using (RegistryKey rkAoTSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
				{
					rkAoTSettings.SetValue("Run at Login", 1);
				}
			}
			else
			{
				using (RegistryKey rkRunAtLogin = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
				{
					rkRunAtLogin.DeleteValue("AlwaysOnTop", false);
				}
				using (RegistryKey rkAoTSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
				{
					rkAoTSettings.SetValue("Run at Login", 0);
				}
			}



			btnApply.Enabled = false;
		}

		
	}
}
