using AlwaysOnTop.Classes;
using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using Utilities;
using System.ComponentModel;
using System.Threading;

namespace AlwaysOnTop
{

	

	public partial class AlwaysOnTop : Form
	{
		public const string version = "0.6.0";
		public const string build = "170118.2018";
		
		public AlwaysOnTop()
		{
			InitializeComponent();
		}

		//private void AlwaysOnTop_Load(object sender, EventArgs e)
		//{

		//}

	}

	public class MyCustomApplicationContext : ApplicationContext
	{
        enum UpdateFrequency
        {
            None = 0,
            Day = 1,
            Week = 7,
            Month = 30
        }

		/*********** ICON DEPENDENCIES *********************/
		[DllImport("user32.dll")]
		static extern bool SetSystemCursor(IntPtr hcur, uint id);

		[DllImport("user32.dll")]
		static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32
		uiParam, String pvParam, UInt32 fWinIni);

		[DllImport("user32.dll")]
		public static extern IntPtr CopyIcon(IntPtr pcur);

		public static uint CROSS = 32515;
		public static uint NORMAL = 32512;
		public static uint IBEAM = 32513;
		/********** END ICON DEPENDENCIES *******************/
		// declare the trayicon

		public string skey;
		public Keys kMod, key;
		globalKeyboardHook gkh;

		string AoTPath = Application.ExecutablePath.ToString();
		string AoTBuild, IP, HK, PW;
		int RaL, UHK, CT, UPM, DBN, CUaS, UFE, UF;
        DateTime LU;
        NotifyIcon trayIcon = new NotifyIcon();

		public MyCustomApplicationContext(string[] args)
		{
            

            

            Assembly _assembly = Assembly.GetExecutingAssembly();
			Stream iconStream = _assembly.GetManifestResourceStream("AlwaysOnTop.icon.ico");

			
			using (RegistryKey rkSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true))
			{
				if (rkSettings == null)
				{
					Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AlwaysOnTop", RegistryKeyPermissionCheck.ReadWriteSubTree);
				}
			}

			RegistryKey regSettings = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AlwaysOnTop", true);
				
			AoTBuild = Methods.TryRegString(regSettings, "Build", AlwaysOnTop.build, true);
			IP = Methods.TryRegString(regSettings, "Installation Path", AoTPath,true);
			RaL = Methods.TryRegInt(regSettings, "Run at Login", 0,false);
			UHK = Methods.TryRegInt(regSettings, "Use Hot Key", 0,false);
			HK = Methods.TryRegString(regSettings, "Hotkey", "",false);
			CT = Methods.TryRegInt(regSettings, "Use Context Menu", 0,false);
			UPM = Methods.TryRegInt(regSettings, "Use Permanent Windows", 0,false);
			PW = Methods.TryRegString(regSettings, "Windows by Title", "",false);
			DBN = Methods.TryRegInt(regSettings, "Disable Balloon Notify", 0, false);
            CUaS = Methods.TryRegInt(regSettings, "Check for Updates at Start", 0, false);
            UFE = Methods.TryRegInt(regSettings, "Update Frequency Enabled", 0, false);
            UF = Methods.TryRegInt(regSettings, "Update Frequency", 0, false);
            try
            {
                LU = DateTime.Parse(Methods.TryRegString(regSettings, "Last check for Update", "na", false));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }


            if (CUaS == 1) { Methods.GetReleases(); }
            /*if (UFE == 1 && UF != 0) { }  ***********************************************************************/

            regSettings.Close();

			try
			{
                // Initialize Tray Icon
                TrayIcon.Icon = new Icon(iconStream);
                TrayIcon.ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("AlwaysOnTop", AoT),
                    new MenuItem("Settings", Settings),
                    new MenuItem("Help", HelpBox),
                    new MenuItem("About", AboutBox),
                    new MenuItem("Exit", Xit)
                });
                TrayIcon.Visible = true;

                TrayIcon.Click += TrayIcon_Click;

                if (DBN != 1)
                {
                    TrayIcon.ShowBalloonTip(5000, "AlwaysOnTop", "AlwaysOnTop is running in the background.", ToolTipIcon.Info);
                }


                if (CT == 1) { /* call method to enabled titlebar context menu*/ }
				if (UHK == 1 && HK != "")
				{
					string delim = "+";
					String[] sHK = HK.Split(new string[] { delim }, StringSplitOptions.None);
					string modifier = sHK[0];
					skey = sHK[1];
					kMod = new Keys();

					switch (modifier.ToLower())
					{
						case "ctrl":
							kMod = Keys.Control;
							break;
						case "alt":
							kMod = Keys.Alt;
							break;
						case "shift":
							kMod = Keys.Shift;
							break;
						case "winkey":
							kMod = Keys.LWin;
							break;
						default:
							kMod = Keys.None;
							break;
					}

					TypeConverter keysConverter = TypeDescriptor.GetConverter(typeof(Keys));
					key = (Keys)keysConverter.ConvertFromString(skey);
					GKH = new globalKeyboardHook();
					GKH.HookedKeys.Add(kMod);
					GKH.HookedKeys.Add(key);

					GKH.KeyUp += new KeyEventHandler(keyup_hook);
					GKH.hook();

					if (DBN != 1)
					{
						TrayIcon.ShowBalloonTip(500, "Settings", kMod + "+" + key + " Hotkey registered", ToolTipIcon.Info);
					}
				}
                else
                {
                    gkh = new globalKeyboardHook();
                }
				if (UPM == 1) { /* call method to enabled titlebar context menu*/ }

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				Xit(this,null);
			}

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        public NotifyIcon TrayIcon
        {
            get { return trayIcon; }
            set { trayIcon = value; }
        }

        globalKeyboardHook GKH
        {
            get { return gkh; }
            set { gkh = value; }
        }

        void keyup_hook(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == kMod && e.KeyCode == key)
			{
				string winTitle = Methods.GetWindowTitle();
				if (DBN != 1)
				{
					trayIcon.ShowBalloonTip(500, "AlwaysOnTop", "Running AlwaysOnTop on " + winTitle, ToolTipIcon.Info);
				}
				string subTitle = "";
				try { subTitle = winTitle.Substring(winTitle.Length - 14); }
				catch { }

				bool isOnTop = false;
				if (subTitle == " - AlwaysOnTop") isOnTop = true;
				if (isOnTop)
				{
					// Disable the AlwaysOnTop
					Methods.AoT_off(winTitle);
				}
				else
				{
					// Enable the AlwaysOnTop
					Methods.AoT_on(winTitle);
				}
				e.Handled = true;
		}

	}

		private void TrayIcon_Click(object sender, EventArgs e) //let left click behave the same as right click
		{
			MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
			mi.Invoke(trayIcon, null);
		}

		void AoT(object sender, EventArgs e)
		{
			//change the cursor
			ChangeCursors();

			//perform the magic
			string winTitle = Methods.GetWindowTitle();
			
			RevertCursors();
			string subTitle = "";
			try { subTitle = winTitle.Substring(winTitle.Length - 14); }
			catch (Exception ex)
			{
                MessageBox.Show(ex.ToString(), "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			bool isOnTop = false;
			if (subTitle == " - AlwaysOnTop") isOnTop = true;
			if (isOnTop)
			{
				// Disable the AlwaysOnTop
				Methods.AoT_off(winTitle);
			}
			else
			{
				// Enable the AlwaysOnTop
				Methods.AoT_on(winTitle);
			}
		}

		public static void ChangeCursors()
		{
			//change normal and ibeam to the cross
			uint[] Cursors = { NORMAL, IBEAM };
			for (int i = 0; i < Cursors.Length; i++)
				SetSystemCursor(CopyIcon(LoadCursor(IntPtr.Zero, (int)CROSS)), Cursors[i]);
		} // ChangeCursors()

		public static void RevertCursors()
		{
			//revert your fuckery, because otherwise it will stay this way
			SystemParametersInfo(0x0057, 0, null, 0);
		} // RevertCursors()

		public static void Settings(object sender, EventArgs e)
		{
            FormSettings settings = new FormSettings();
            settings.ShowDialog();
		}

		void HelpBox(object sender, EventArgs e)
		{
			FormHelp help = new FormHelp();
			help.ShowDialog();
		} // HelpBox()

		void AboutBox(object sender, EventArgs e)
		{
			FormAbout about = new FormAbout();
			about.ShowDialog();
		} // AboutBox()

        private void OnApplicationExit(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            GKH.unhook();
        }

		public void Xit(object sender, EventArgs e)
		{
            Application.Exit();
		} // Xit()
	}

	
}
