using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using org.lmp.TestWindowPos.Win32;
using org.lmp.TestWindowPos.Properties;

namespace org.lmp.TestWindowPos
{
	public class WindowPlacement
	{
		public void SaveWindow(Control window)
		{
			// TODO
		}

		public void RestoreWindow(Control window)
		{
			// TODO
		}

		private WINDOWPLACEMENT windowPlacement;

		private void Save()
		{
			Settings.Default.WindowPlacementFlags = windowPlacement.flags;
			Settings.Default.WindowPlacementShowCmd = windowPlacement.showCmd;
			Settings.Default.WindowPlacementMin = POINTToPoint(windowPlacement.minPosition);
			Settings.Default.WindowPlacementMax = POINTToPoint(windowPlacement.maxPosition);
			Settings.Default.WindowPlacementNormalPoint = new Point(windowPlacement.normalPosition.Left, windowPlacement.normalPosition.Top);
			Settings.Default.WindowPlacementNormalSize = new Size(windowPlacement.normalPosition.Right - windowPlacement.normalPosition.Left, windowPlacement.normalPosition.Bottom - windowPlacement.normalPosition.Top);
			Settings.Default.Save();
		}

		private void Load()
		{
			windowPlacement.flags = Settings.Default.WindowPlacementFlags;
			windowPlacement.showCmd = Settings.Default.WindowPlacementShowCmd;
			windowPlacement.minPosition = new POINT(Settings.Default.WindowPlacementMin);
			windowPlacement.maxPosition = new POINT(Settings.Default.WindowPlacementMax);
			windowPlacement.normalPosition = new RECT(Settings.Default.WindowPlacementNormalPoint, Settings.Default.WindowPlacementNormalSize);
		}

		private static Point POINTToPoint(POINT pt)
		{
			return new Point(pt.X, pt.Y);
		}
	}
}
