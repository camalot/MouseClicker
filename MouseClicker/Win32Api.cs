using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MouseClicker {
	internal class Win32Api {
		public const int MOUSEEVENTF_MOVE = 0x0001;
		public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
		public const int MOUSEEVENTF_LEFTUP = 0x0004;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
		public const int MOUSEEVENTF_RIGHTUP = 0x0010;
		public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
		public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
		public const int MOUSEEVENTF_XDOWN = 0x0080;
		public const int MOUSEEVENTF_XUP = 0x0100;
		public const int MOUSEEVENTF_WHEEL = 0x0800;
		public const int MOUSEEVENTF_VIRTUALDESK = 0x4000;
		public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

		public struct POINT {
			public int x;
			public int y;
		}


		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr WindowFromPoint(Point point);

		[DllImport("user32.dll")]
		static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern int GetWindowTextLength(IntPtr hWnd);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
		/// <summary>
		/// Retrieves the cursor's position, in screen coordinates.
		/// </summary>
		/// <see>See MSDN documentation for further information.</see>
		[DllImport("user32.dll")]
		static extern bool GetCursorPos(out POINT lpPoint);

		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

		private static IntPtr MAKELPARAM(int x, int y) {
			return new IntPtr(((y << 16) | (x & 0xFFFF)));
		}

		public static void MoveAndClick(Point point) {
			var pt = new POINT() {  x = point.X, y = point.Y };
			SetCursorPos(point.X, point.Y);
			mouse_event(Win32Api.MOUSEEVENTF_LEFTDOWN | Win32Api.MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0);
		}

		// This crashes the window that I tested it on.
		public static void SendClick(IntPtr handle, Point point) {
			var pt = new POINT() { x = point.X, y = point.Y };
			ScreenToClient(handle, ref pt);
			Console.WriteLine("{0}:{1}", pt.x, pt.y);
			PostMessage(handle, (uint)MOUSEEVENTF_LEFTDOWN, IntPtr.Zero, MAKELPARAM(pt.x, pt.y));
			PostMessage(handle, (uint)MOUSEEVENTF_LEFTUP, IntPtr.Zero, MAKELPARAM(pt.x, pt.y));
			SendMessage(handle, (uint)MOUSEEVENTF_LEFTDOWN, IntPtr.Zero, MAKELPARAM(pt.x, pt.y));
			SendMessage(handle, (uint)MOUSEEVENTF_LEFTUP, IntPtr.Zero, MAKELPARAM(pt.x, pt.y));
		}

		public static Point GetCursorPosition() {
			POINT lpPoint;
			GetCursorPos(out lpPoint);

			return new Point(lpPoint.x, lpPoint.y);
		}

		public static IntPtr FindWindowFromPoint(Point point) {
			return WindowFromPoint(point.X, point.Y);
		}

		public static IntPtr FindWindowFromCaption(string caption) {
			return FindWindowByCaption(IntPtr.Zero, caption);
		}

		public static string GetWindowCaption(IntPtr hWnd) {
			int capacity = GetWindowTextLength(hWnd) * 2;
			var stringBuilder = new StringBuilder(capacity);
			GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}
	}
}
