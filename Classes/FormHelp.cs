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
	public partial class FormHelp : Form
	{
		public FormHelp()
		{
			InitializeComponent();
		}

		private void FormHelp_Load(object sender, EventArgs e)
		{

		}

		private void btnRevertArrow_Click(object sender, EventArgs e)
		{
			MyCustomApplicationContext.RevertCursors();
		}
	}
}
