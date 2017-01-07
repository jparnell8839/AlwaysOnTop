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
		bool MustRestart = false;
		string HK, PW;
		int RaL, UHK, CT, UPM, DBN;

		public FormSettings()
		{
			InitializeComponent();
		}

		private void FormSettings_Load(object sender, EventArgs e)
		{
			chkTitleContext.Enabled = false;
			chkPermWindows.Enabled = false;
			btnSelectWindows.Enabled = false;
			listPermWindows.Enabled = false;

			using (RegistryKey regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				

				RaL = Methods.TryRegInt(regSettings, "Run at Login", 0, false);
				UHK = Methods.TryRegInt(regSettings, "Use Hot Key", 0, false);
				HK = Methods.TryRegString(regSettings, "Hotkey", "", false);
				CT = Methods.TryRegInt(regSettings, "Use Context Menu", 0, false);
				UPM = Methods.TryRegInt(regSettings, "Use Permanent Windows", 0, false);
				PW = Methods.TryRegString(regSettings, "Windows by Title", "", false);
				DBN = Methods.TryRegInt(regSettings, "Disable Balloon Notify", 0, false);

				if (RaL == 1) {	chkRunAtLogin.Checked = true; }
				if (UHK == 1) { chkHotKey.Checked = true; }
				if (HK != "")
				{
					string delim = "+";
					String[] sHK = HK.Split(new string[] { delim },StringSplitOptions.None);
					string modifier = sHK[0];
					string key = sHK[1];
				}
				if (CT == 1) { chkTitleContext.Checked = true; }
				if (UPM == 1) { chkPermWindows.Checked = true; }
				if (PW != "") { /* - The listbox for the permanent AoT windows gets populated */ }
				if (DBN == 1) { chkDisableBalloonNotify.Checked = true; }
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

		private void chkDisableBalloonNotify_CheckedChanged(object sender, EventArgs e)
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
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
					}


					#endregion

					#region chkUseHotKey
					try
					{
						if (chkHotKey.Checked)
						{
							Methods.TryRegInt(regSettings, "Use Hot Key", 1, true);
							MustRestart = true;
						}
						else
						{
							Methods.TryRegInt(regSettings, "Use Hot Key", 0, true);
							MustRestart = true;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					#endregion

					#region chkDisableBalloonNotify
					try
					{
						if (chkDisableBalloonNotify.Checked)
						{
							Methods.TryRegInt(regSettings, "Disable Balloon Notify", 1, true);
							MustRestart = true;
						}
						else
						{
							Methods.TryRegInt(regSettings, "Disable Balloon Notify", 0, false);
							MustRestart = true;
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					#endregion
				}
			}


			if (MustRestart)
			{
				DialogResult restart = MessageBox.Show("You must restart AlwaysOnTop to apply these settings." + Environment.NewLine + "Restart now?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				switch (restart)
				{
					case DialogResult.Yes:
						Application.Restart();
						break;
					case DialogResult.No:
						break;
					default:
						break;
				}
			}


			btnApply.Enabled = false;
		}

		private void btnSetHotkey_Click(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
			FormSetHotkey setHotKey = new FormSetHotkey();
			setHotKey.ShowDialog();
		}
	}
}
