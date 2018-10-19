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
	public static class WindowPlacement
	{
		public static void SaveWindow(Control window)
		{
			WINDOWPLACEMENT windowPlacement;
			Win32Func.GetWindowPlacement(window.Handle, out windowPlacement);
			Settings.Default.WindowPlacementFlags = windowPlacement.flags;
			Settings.Default.WindowPlacementShowCmd = windowPlacement.showCmd;
			Settings.Default.WindowPlacementMin = POINTToPoint(windowPlacement.minPosition);
			Settings.Default.WindowPlacementMax = POINTToPoint(windowPlacement.maxPosition);
			Settings.Default.WindowPlacementNormalPoint = new Point(windowPlacement.normalPosition.Left, windowPlacement.normalPosition.Top);
			Settings.Default.WindowPlacementNormalSize = new Size(windowPlacement.normalPosition.Right - windowPlacement.normalPosition.Left, windowPlacement.normalPosition.Bottom - windowPlacement.normalPosition.Top);
			Settings.Default.Save();
		}

		public static void RestoreWindow(Control window)
		{
			if (!Settings.Default.WindowPlacementNormalSize.IsEmpty) {
				WINDOWPLACEMENT windowPlacement;
				windowPlacement.length = System.Runtime.InteropServices.Marshal.SizeOf(typeof(WINDOWPLACEMENT));
				windowPlacement.flags = Settings.Default.WindowPlacementFlags;
				windowPlacement.showCmd = Settings.Default.WindowPlacementShowCmd;
				windowPlacement.minPosition = new POINT(Settings.Default.WindowPlacementMin);
				windowPlacement.maxPosition = new POINT(Settings.Default.WindowPlacementMax);
				windowPlacement.normalPosition = new RECT(Settings.Default.WindowPlacementNormalPoint, Settings.Default.WindowPlacementNormalSize);
				if (windowPlacement.showCmd == Win32Const.SW_SHOWMINIMIZED)
					windowPlacement.showCmd = Win32Const.SW_SHOWNORMAL;
				Win32Func.SetWindowPlacement(window.Handle, ref windowPlacement);
			}
		}

		private static Point POINTToPoint(POINT pt)
		{
			return new Point(pt.X, pt.Y);
		}
	}
}
