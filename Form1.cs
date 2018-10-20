using System;
using System.Windows.Forms;

namespace org.lmp.TestWindowPos
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Set the window position to the saved position from last time.
			WindowPlacement.RestoreWindow(this);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Save the window position for next time.
			WindowPlacement.SaveWindow(this);
		}
	}
}
