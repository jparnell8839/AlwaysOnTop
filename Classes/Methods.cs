using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

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


		public static String GetWindowTitle()
		{
			int i = 0;
			while (i < 1)
			{
				const int nChars = 256;
				StringBuilder Buff = new StringBuilder(nChars);
				IntPtr handle = GetForegroundWindow();

				if (GetWindowText(handle, Buff, nChars) > 0)
				{
					return Buff.ToString();
				}
			}
			return null;
		} // GetWindowTitle()

		public static void AoT_on(string title)
		{
			Process[] processes = Process.GetProcesses(".");
			foreach (var process in processes)
			{
				string mWinTitle = process.MainWindowTitle.ToString();
				if (mWinTitle == title)
				{
					IntPtr handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
						string newTitle = title + " - AlwaysOnTop";
						SetWindowText(handle, newTitle);
					}
				}
				
			}
		} // AoT_on()

		public static void AoT_off(string title)
		{
			Process[] processes = Process.GetProcesses(".");
			foreach (var process in processes)
			{
				string mWinTitle = process.MainWindowTitle.ToString();
				if ( mWinTitle == title)
				{
					IntPtr handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
						string newTitle = title.Substring(0,title.Length - 14);
						SetWindowText(handle, newTitle);
					}
				}
			}
		} // AoT_off()
	}
}
