using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace MouseClicker {
	public partial class Form1 : Form {
		KeyboardHook hook = null;

		private string hotKey = "(CTRL+SHIFT+ALT+M)";

		System.Threading.Timer tmr = null;
		System.Threading.Timer tmr2 = null;


		public Form1() {
			InitializeComponent();

		}

		private bool IsDragging { get; set; }
		private bool IsRunning { get; set; }
		private Point DragPoint { get; set; }
		private bool IsDragSet { get; set; }
		private IntPtr hWnd { get; set; }
		private void start_Click(object sender, EventArgs e) {
			if(hook == null) {
				hook = new KeyboardHook();
				hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
				hook.RegisterHotKey(MouseClicker.ModifierKeys.Alt | MouseClicker.ModifierKeys.Shift | MouseClicker.ModifierKeys.Control, Keys.M);
				status.Text = string.Format("Waiting for HotKey {0}", hotKey);
				reset.Enabled = false;
				start.Text = "Stop Listening for HotKey";
			} else {
				start.Text = "Start Listening for HotKey";
				IsRunning = false;
				if(tmr != null) {
					tmr.Dispose();
				}
				if(tmr2 != null) {
					tmr2.Dispose();
				}
				tmr = null;
				tmr2 = null;
				hook.Dispose();
				this.numericUpDown1.Enabled = true;
				status.Text = "Not Running...";
				hook = null;
			}
		}

		void hook_KeyPressed(object sender, KeyPressedEventArgs e) {

			if(!IsRunning) {
				if (!IsDragSet) {
					status.Text = "Set Target...Not Running...";
					return;
				}
				IsRunning = true;

				status.Text = string.Format("Running... Press {0} to stop", hotKey);
				if ( this.enableClick.Checked ) {
					tmr = new System.Threading.Timer ( new TimerCallback ( delegate ( object state ) {
						Win32Api.MoveAndClick(DragPoint);
					} ), null, (long)this.numericUpDown1.Value, (long)this.numericUpDown1.Value );
				}

				if(!string.IsNullOrEmpty(keys.Text) && enableKeys.Enabled) {
					tmr2 = new System.Threading.Timer(new TimerCallback(delegate(object state) {
						Console.WriteLine ( $"Sending {keys.Text}" );
						SendKeys.SendWait(state.ToString());
					}), keys.Text, 0L, (long)this.numericUpDown2.Value);
				}
			} else {
				IsRunning = false;
				status.Text = "Not Running...";
				if(tmr != null) {
					tmr.Dispose();
				}
				if(tmr2 != null) {
					tmr2.Dispose();
				}
			}
			this.numericUpDown1.Enabled = !IsRunning;
			this.numericUpDown2.Enabled = !IsRunning;
			this.keys.Enabled = !IsRunning;
			enableClick.Enabled = !IsRunning;
			enableKeys.Enabled = !IsRunning;
			start.Enabled = !IsRunning;
			reset.Enabled = !IsRunning;

		}

		private void handleImage_MouseDown(object sender, MouseEventArgs e) {
			if(!IsDragging) {
				IsDragging = true;
			}
		}

		private void handleImage_MouseMove(object sender, MouseEventArgs e) {
			if(IsDragging) {
				this.target.Visible = true;
				DragPoint = Win32Api.GetCursorPosition();
				this.target.Text = DragPoint.ToString();
			}
		}

		private void handleImage_MouseUp(object sender, MouseEventArgs e) {
			if(IsDragging) {
				this.target.Visible = true;
				DragPoint = Win32Api.GetCursorPosition();
				this.target.Text = DragPoint.ToString();
				this.hWnd = Win32Api.WindowFromPoint(DragPoint);

				IsDragging = false;
				IsDragSet = true;
				start.Enabled = true;
				reset.Enabled = true;
			}
		}

		private void reset_Click(object sender, EventArgs e)
		{
			this.target.Visible = false;
			IsDragSet = false;
			start.Enabled = false;
			reset.Enabled = false;
			DragPoint = Point.Empty;
		}
	}
}
