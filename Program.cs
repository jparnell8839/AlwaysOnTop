/********************************************
 *	AlwaysOnTop
 *	Code:		Joshua Parnell
 *	Site:		https://github.com/jparnell8839/AlwaysOnTop
 *	Version:	0.3.1
 *	Build:		161230.2047
 *	Date:		2016-12-30
 *	Credits:	John Parnell for assistance with original AutoIt version's aot() logic
 *				Sayka & dimitris93 for the cursor changing logic
 *					http://stackoverflow.com/questions/29781271/setsystemcursor-for-multiple-cursors-behavior
 *				Hans Passant for the left click logic to bring the context menu
 *					http://stackoverflow.com/questions/2208690/invoke-notifyicons-context-menu/
 *				Jorge Ferreira for window title logic
 *					http://stackoverflow.com/questions/115868/how-do-i-get-the-title-of-the-current-active-window-using-c
 *					
 ********************************************/

using System;
using System.IO;
using System.Windows.Forms;

namespace AlwaysOnTop
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		[STAThread]
		static void Main()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "\\AoT_Error.log";
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new MyCustomApplicationContext());
			}
			catch(Exception ex)
			{
				using (StreamWriter error = new StreamWriter(path, true))
				{
					error.WriteLine(DateTime.Now + ": " + ex.Message);
				}
			}
			
		}
	}
}
