using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MouseClicker {
	public static class SendInputClass {

		[DllImport("user32.dll", SetLastError = true)]
		static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

		[DllImport("user32.dll")]
		static extern bool SetCursorPos(int X, int Y);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetCursorPos(out Point lpPoint);



		[StructLayout(LayoutKind.Sequential)]
		struct INPUT {
			public SendInputEventType type;
			public MouseKeybdhardwareInputUnion mkhi;
		}
		[StructLayout(LayoutKind.Explicit)]
		struct MouseKeybdhardwareInputUnion {
			[FieldOffset(0)]
			public MouseInputData mi;

			[FieldOffset(0)]
			public KEYBDINPUT ki;

			[FieldOffset(0)]
			public HARDWAREINPUT hi;
		}
		[StructLayout(LayoutKind.Sequential)]
		struct KEYBDINPUT {
			public ushort wVk;
			public ushort wScan;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}
		[StructLayout(LayoutKind.Sequential)]
		struct HARDWAREINPUT {
			public int uMsg;
			public short wParamL;
			public short wParamH;
		}
		struct MouseInputData {
			public int dx;
			public int dy;
			public uint mouseData;
			public MouseEventFlags dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}
		[Flags]
		public enum MouseEventFlags : uint {
			MOUSEEVENTF_MOVE = 0x0001,
			MOUSEEVENTF_LEFTDOWN = 0x0002,
			MOUSEEVENTF_LEFTUP = 0x0004,
			MOUSEEVENTF_RIGHTDOWN = 0x0008,
			MOUSEEVENTF_RIGHTUP = 0x0010,
			MOUSEEVENTF_MIDDLEDOWN = 0x0020,
			MOUSEEVENTF_MIDDLEUP = 0x0040,
			MOUSEEVENTF_XDOWN = 0x0080,
			MOUSEEVENTF_XUP = 0x0100,
			MOUSEEVENTF_WHEEL = 0x0800,
			MOUSEEVENTF_VIRTUALDESK = 0x4000,
			MOUSEEVENTF_ABSOLUTE = 0x8000
		}
		enum SendInputEventType : int {
			InputMouse,
			InputKeyboard,
			InputHardware
		}

		public static void ClickLeftMouseButton(int x, int y) {
			INPUT mouseInput = new INPUT();
			mouseInput.type = SendInputEventType.InputMouse;
			mouseInput.mkhi.mi.dx = x;
			mouseInput.mkhi.mi.dy = y;
			mouseInput.mkhi.mi.mouseData = 0;

			//getting current cursor location
			Point p;
			if(GetCursorPos(out p))
				SetCursorPos(x, y);


			mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN | MouseEventFlags.MOUSEEVENTF_ABSOLUTE;
			SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));

			mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP | MouseEventFlags.MOUSEEVENTF_ABSOLUTE;
			SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));

			//returning cursor to previous position
			SetCursorPos(p.X, p.Y);
		}
	}
}
