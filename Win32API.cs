using System;
using System.Runtime.InteropServices;

/// <summary>
/// C# definitions for Win32 structs, constants and functions
/// </summary>
namespace org.lmp.TestWindowPos.Win32
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public RECT(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		public RECT(System.Drawing.Point pt,System.Drawing.Size size)
		{
			this.Left = pt.X;
			this.Top = pt.Y;
			this.Right = pt.X + size.Width;
			this.Bottom = pt.Y + size.Height;
		}
	}

	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;

		public POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public POINT(System.Drawing.Point pt)
		{
			this.X = pt.X;
			this.Y = pt.Y;
		}
	}

	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPLACEMENT
	{
		public int length;
		public int flags;
		public int showCmd;
		public POINT minPosition;
		public POINT maxPosition;
		public RECT normalPosition;
	}

	public static class Win32Const
	{
		public const int SW_SHOWNORMAL = 1;
		public const int SW_SHOWMINIMIZED = 2;
	}

	public static class Win32Func
	{
		[DllImport("user32.dll")]
		public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);
	}
}
