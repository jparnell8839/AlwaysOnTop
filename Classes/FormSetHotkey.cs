using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace AlwaysOnTop.Classes
{
    public partial class FormSetHotkey : Form
	{
		public string hotkey, HK;

		public FormSetHotkey()
		{
			InitializeComponent();
		}

		void FormSetHotkey_Load(object sender, EventArgs e)
		{
			using (var regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				HK = Methods.TryRegString(regSettings, "Hotkey", "", false);
				if (HK != "") { txtHotkey.Text = HK; };
			}
		}

		void btnSetKey_Click(object sender, EventArgs e)
		{
			btnSetKey.Enabled = false;
			txtHotkey.Text = "";
			hotkey = "";
		}

		void SetHotkey_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode != Keys.Back)
				{
					var modifierKeys = e.Modifiers;
					var pressedKey = e.KeyData;

					if (modifierKeys != Keys.None && pressedKey != Keys.None)
					{
						if (e.KeyData == (Keys.Control | Keys.A))
						{
							MessageBox.Show("Ctrl + A is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.S))
						{
							MessageBox.Show("Ctrl + S is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.F))
						{
							MessageBox.Show("Ctrl + F is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.Z))
						{
							MessageBox.Show("Ctrl + Z is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.X))
						{
							MessageBox.Show("Ctrl + X is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.C))
						{
							MessageBox.Show("Ctrl + C is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Control | Keys.V))
						{
							MessageBox.Show("Ctrl + V is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.LWin | Keys.E))
						{
							MessageBox.Show("Win + E is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.LWin | Keys.Tab))
						{
							MessageBox.Show("Win + Tab is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.LWin | Keys.R))
						{
							MessageBox.Show("Win + R is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else if (e.KeyData == (Keys.Alt | Keys.Tab))
						{
							MessageBox.Show("Alt + Tab is not an allowed combination. Please choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							e.Handled = false;
							e.SuppressKeyPress = true;

							txtHotkey.Text = "";
							hotkey = "";
						}
						else
						{
							var converter = new KeysConverter();
							hotkey = converter.ConvertToString(e.KeyData);
							txtHotkey.Text = hotkey;
							btnApply.Enabled = true;
						}
					}
				}
				else
				{
					e.Handled = false;
					e.SuppressKeyPress = true;

					txtHotkey.Text = "";
				}
				btnSetKey.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			
		}

		void btnApply_Click(object sender, EventArgs e)
		{
			using (var regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				Methods.TryRegString(regSettings, "Hotkey", hotkey, true);
			}

			btnApply.Enabled = false;
		}

		void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}

		
	}
