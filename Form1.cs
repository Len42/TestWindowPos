﻿using System;
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
			WindowPlacement.RestoreWindow(this);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			WindowPlacement.SaveWindow(this);
		}
	}
}
