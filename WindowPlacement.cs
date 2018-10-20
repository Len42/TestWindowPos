using System;
using System.Drawing;
using System.Windows.Forms;
using org.lmp.TestWindowPos.Win32;
using org.lmp.TestWindowPos.Properties;

namespace org.lmp.TestWindowPos
{
	/// <summary>
	/// Save a window's position and restore it the next time the application is run
	/// </summary>
	public static class WindowPlacement
	{
		public static void SaveWindow(Control window)
		{
			SaveWindow(window.Handle);
		}

		public static void SaveWindow(IntPtr hwnd)
		{
			WINDOWPLACEMENT windowPlacement;
			Win32Func.GetWindowPlacement(hwnd, out windowPlacement);
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
			RestoreWindow(window.Handle);
		}

		public static void RestoreWindow(IntPtr hwnd)
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
				Win32Func.SetWindowPlacement(hwnd, ref windowPlacement);
			}
		}

		private static Point POINTToPoint(POINT pt)
		{
			return new Point(pt.X, pt.Y);
		}
	}
}
