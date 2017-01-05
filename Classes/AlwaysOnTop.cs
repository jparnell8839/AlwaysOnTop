using AlwaysOnTop.Classes;
using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AlwaysOnTop
{
	public partial class AlwaysOnTop : Form
	{
		public const string version = "0.4.2";
		public const string build = "170104.2106";		
		
		public AlwaysOnTop()
		{
			InitializeComponent();
		}

		private void AlwaysOnTop_Load(object sender, EventArgs e)
		{
			
		}
	}

	public class MyCustomApplicationContext : ApplicationContext
	{
		

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
		private NotifyIcon trayIcon;

		public MyCustomApplicationContext()
		{
			string AoTPath = Application.ExecutablePath.ToString();
			string AoTBuild, IP, HK, PW;
			int RaL, UHK, CT, UPM;

			Assembly _assembly = Assembly.GetExecutingAssembly();
			Stream iconStream = _assembly.GetManifestResourceStream("AlwaysOnTop.icon.ico");

			try
			{
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

				// Initialize Tray Icon
				trayIcon = new NotifyIcon()
				{
					Icon = new Icon(iconStream),
					ContextMenu = new ContextMenu(new MenuItem[] 
					{
					new MenuItem("AlwaysOnTop", AoT),
					new MenuItem("Settings", Settings),
					new MenuItem("Help", HelpBox),
					new MenuItem("About", AboutBox),
					new MenuItem("Exit", Xit)
					}),
					Visible = true
				};
				trayIcon.Click += TrayIcon_Click;
				trayIcon.ShowBalloonTip(5000, "AlwaysOnTop", "AlwaysOnTop is running in the background.", ToolTipIcon.Info);

				if (CT == 1) { /* call method to enabled titlebar context menu*/ }
				if (UHK == 1) { /* call method to enabled titlebar context menu*/ }
				if (UPM == 1) { /* call method to enabled titlebar context menu*/ }

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				Xit(this,null);
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
				//trayIcon.ShowBalloonTip(5000, "AlwaysOnTop", ex.Message, ToolTipIcon.Error);
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

		void Xit(object sender, EventArgs e)
		{
			// Hide tray icon, otherwise it will remain shown until user mouses over it
			trayIcon.Visible = false;
			Application.Exit();
		} // Xit()


		











	}

	
}
