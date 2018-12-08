/********************************************
 *	AlwaysOnTop
 *	Code:		Joshua Parnell
 *	Site:		https://github.com/jparnell8839/AlwaysOnTop
 *	Version:	0.5.2
 *	Build:		170106.2235
 *	Date:		2017.01.10
 *	Credits:	John Parnell for assistance with original AutoIt version's aot() logic
 *				Sayka & dimitris93 for the cursor changing logic
 *					http://stackoverflow.com/questions/29781271/setsystemcursor-for-multiple-cursors-behavior
 *				Hans Passant for the left click logic to bring the context menu
 *					http://stackoverflow.com/questions/2208690/invoke-notifyicons-context-menu/
 *				Jorge Ferreira for window title logic
 *					http://stackoverflow.com/questions/115868/how-do-i-get-the-title-of-the-current-active-window-using-c
 *				StormySpike for the use of the globalKeyboardHook class
 *					https://www.codeproject.com/kb/cs/csllkeyboardhook.aspx
 *				Jon Egerton for enabling the modifer keys on globalKeyboardHook
 *					http://www.jonegerton.com/dotnet/determining-the-state-of-modifier-keys-when-hooking-keyboard-input/
 *				Octokit for the GitHub API classes and updating
 *				    https://github.com/octokit/octokit.net
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
		static void Main(string[] args)
		{
			var path = AppDomain.CurrentDomain.BaseDirectory + "\\AoT_Error.log";
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new MyCustomApplicationContext(args));
			}
			catch(Exception ex)
			{
				using (var error = new StreamWriter(path, true))
				{
					error.WriteLine(DateTime.Now + ": " + ex.Message);
				}
			}
			
		}
	}
}
