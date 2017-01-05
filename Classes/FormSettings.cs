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

		public FormSettings()
		{
			InitializeComponent();
		}

		private void FormSettings_Load(object sender, EventArgs e)
		{
			chkTitleContext.Enabled = false;
			chkHotKey.Enabled = false;
			chkPermWindows.Enabled = false;
			btnSelectWindows.Enabled = false;
			listPermWindows.Enabled = false;

			using (RegistryKey regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				string HK, PW;
				int RaL, UHK, CT, UPM;

				RaL = Methods.TryRegInt(regSettings, "Run at Login", 0, false);
				UHK = Methods.TryRegInt(regSettings, "Use Hot Key", 0, false);
				HK = Methods.TryRegString(regSettings, "Hotkey", "", false);
				CT = Methods.TryRegInt(regSettings, "Use Context Menu", 0, false);
				UPM = Methods.TryRegInt(regSettings, "Use Permanent Windows", 0, false);
				PW = Methods.TryRegString(regSettings, "Windows by Title", "", false);

				if (RaL == 1) {	chkRunAtLogin.Checked = true; }
				if (UHK == 1) { chkHotKey.Checked = true; }
				if (HK != "") { /* - The inputbox (?) for the Hotkey assignment gets populated */ }
				if (CT == 1) { chkTitleContext.Checked = true; }
				if (UPM == 1) { chkPermWindows.Checked = true; }
				if (PW != "") { /* - The listbox for the permanent AoT windows gets populated */ }
			}



			btnApply.Enabled = false; // Make this one last so a potential change from registry settings doesn't enable it.
		}

		private void chkRunAtLogin_CheckedChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}

		private void chkTitleContext_CheckedChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}

		private void chkHotKey_CheckedChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}

		private void chkPermWindows_CheckedChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}

		private void btnSelectWindows_Click(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			using (RegistryKey regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				using (RegistryKey regRunAtLogin = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
				{
					#region chkRunAtLogin
					try
					{
						if (chkRunAtLogin.Checked)
						{
							regRunAtLogin.SetValue("AlwaysOnTop", AoTPath);
							Methods.TryRegInt(regSettings, "Run at Login", 1, true);
						}
						else
						{
							regRunAtLogin.DeleteValue("AlwaysOnTop", false);
							Methods.TryRegInt(regSettings, "Run at Login", 0, true);
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("ERROR", "An error occurred." + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					#endregion

					#region chkTitleContext
					try
					{
						if (chkTitleContext.Checked)
						{
							Methods.TryRegInt(regSettings, "Use Context Menu", 1, true);
							// call method to add title bar context menu option on all windows
						}
						else
						{
							Methods.TryRegInt(regSettings, "Use Context Menu", 0, true);
							// call method to disable title bar context menu option on all windows
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("ERROR", "An error occurred." + Environment.NewLine + ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
					}


					#endregion

					#region chkUseHotKey
					try
					{
						if (chkHotKey.Checked)
						{

						}
						else
						{

						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("ERROR", "An error occurred." + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}


					#endregion

					#region chkPermWindows
					try
					{
						if (chkPermWindows.Checked)
						{

						}
						else
						{

						}
						
					}
					catch (Exception ex)
					{
						MessageBox.Show("ERROR", "An error occurred." + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					#endregion
				}
			}

				



			btnApply.Enabled = false;
		}

		
	}
}
