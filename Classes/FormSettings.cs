using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace AlwaysOnTop.Classes
{
    public partial class FormSettings : Form
	{
		readonly string AoTPath = Application.ExecutablePath;
		bool MustRestart = false;
		string HK, PW;
		string[] sHK = new string[2];
		const char Delim = '+';

		int RaL, UHK, CT, UPM, DBN, CUaS, UFE, UF;

		enum UpdateFrequency
		{
			None = 0,
			Day = 1,
			Week = 7,
			Month = 30
		}
		
		public FormSettings()
		{
            InitializeComponent();
		}

		void FormSettings_Load(object sender, EventArgs e)
		{
			chkTitleContext.Enabled = false;
			chkPermWindows.Enabled = false;
			btnSelectWindows.Enabled = false;
			listPermWindows.Enabled = false;

			using (var regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
                RaL = Methods.TryRegInt(regSettings, "Run at Login", 0, false);
                UHK = Methods.TryRegInt(regSettings, "Use Hot Key", 0, false);
                HK = Methods.TryRegString(regSettings, "Hotkey", "", false);
                CT = Methods.TryRegInt(regSettings, "Use Context Menu", 0, false);
                UPM = Methods.TryRegInt(regSettings, "Use Permanent Windows", 0, false);
                PW = Methods.TryRegString(regSettings, "Windows by Title", "", false);
                DBN = Methods.TryRegInt(regSettings, "Disable Balloon Notify", 0, false);
                CUaS = Methods.TryRegInt(regSettings, "Check for Updates at Start", 0, false);
                UFE = Methods.TryRegInt(regSettings, "Update Frequency Enabled", 0, false);
                UF = Methods.TryRegInt(regSettings, "Update Frequency", 0, false);

                if (RaL == 1) {	chkRunAtLogin.Checked = true; }
                if (UHK == 1) { chkHotKey.Checked = true; }

                if (!String.IsNullOrWhiteSpace(HK))
				{
                    sHK = HK.Split(Delim);
				}
                else
                {
                    sHK[0] = "";
                    sHK[1] = "";
                }

                if (CT == 1) { chkTitleContext.Checked = true; }
                if (UPM == 1) { chkPermWindows.Checked = true; }
                if (PW != "") { /* - The listbox for the permanent AoT windows gets populated */ }
                if (DBN == 1) { chkDisableBalloonNotify.Checked = true; }
                if (CUaS == 1) { chkUpdateStart.Checked = true; }
                if (UFE == 1)
                {
                    chkUpdateFreq.Checked = true;
                    switch (UF)
                    {
                        case 1 :
                            cmbUpdateFreq.SelectedIndex = 1;
                            break;
                        case 7:
                            cmbUpdateFreq.SelectedIndex = 2;
                            break;
                        case 30:
                            cmbUpdateFreq.SelectedIndex = 3;
                            break;
                        default:
                            cmbUpdateFreq.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    cmbUpdateFreq.SelectedIndex = 0;
                }

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

        private void chkUpdateStart_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void chkUpdateFreq_CheckedChanged(object sender, EventArgs e)
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
			using (var regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				using (var regRunAtLogin = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
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
							Methods.TryRegInt(regSettings, "Disable Balloon Notify", 0, true);
							MustRestart = true;
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

                    #endregion

                    #region chkUpdateStart
                    try
                    {
                        if (chkUpdateStart.Checked)
                        {
                            Methods.TryRegInt(regSettings, "Check for Updates at Start", 1, true);
                        }
                        else
                        {
                            Methods.TryRegInt(regSettings, "Check for Updates at Start", 0, true);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred." + Environment.NewLine + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    #endregion

                    #region chkUpdateFrequency
                    try
                    {
                        if (chkUpdateFreq.Checked)
                        {
                            if (cmbUpdateFreq.SelectedIndex != 0)
                            {
                                UpdateFrequency freq;
                                switch (cmbUpdateFreq.SelectedIndex)
                                {
                                    case 1:
                                        freq = UpdateFrequency.Day;
                                        break;
                                    case 2:
                                        freq = UpdateFrequency.Week;
                                        break;
                                    case 3:
                                        freq = UpdateFrequency.Month;
                                        break;
                                    default:
                                        freq = UpdateFrequency.None;
                                        break;
                                }

                                Methods.TryRegInt(regSettings, "Update Frequency Enabled", 0, true);
                                Methods.TryRegInt(regSettings, "Update Frequency", (int)freq, true);
                                MustRestart = true;
                            }
                            else
                            {
                                MessageBox.Show("You must select an update frequency!", "Cannot Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            Methods.TryRegInt(regSettings, "Update Frequency Enabled", 0, true);
                            Methods.TryRegInt(regSettings, "Update Frequency", 0, true);
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
				var restart = MessageBox.Show("You must restart AlwaysOnTop to apply these settings." + Environment.NewLine +
                    "Restart now?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				switch (restart)
				{
					case DialogResult.Yes:
						Application.Restart();
						break;
					case DialogResult.No:
                        MessageBox.Show("Settings will take effect the next time you start AlwaysOnTop", "You sure about that?", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			var setHotKey = new FormSetHotkey();
			setHotKey.ShowDialog();
		}
	}
}
