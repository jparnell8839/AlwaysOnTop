/********************************************
 *	AlwaysOnTop
 *	Code:		Joshua Parnell
 *	Site:		https://github.com/jparnell8839/AlwaysOnTop
 *	Version:	0.3.0
 *	Build:		161230.0220
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MyCustomApplicationContext());

			
		}
	}
}
