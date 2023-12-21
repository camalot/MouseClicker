namespace MouseClicker {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.start = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.status = new System.Windows.Forms.Label();
			this.keys = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.handleImage = new System.Windows.Forms.PictureBox();
			this.target = new System.Windows.Forms.Label();
			this.enableClick = new System.Windows.Forms.CheckBox();
			this.reset = new System.Windows.Forms.Button();
			this.enableKeys = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.handleImage)).BeginInit();
			this.SuspendLayout();
			// 
			// start
			// 
			this.start.Enabled = false;
			this.start.Location = new System.Drawing.Point(12, 12);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(370, 36);
			this.start.TabIndex = 0;
			this.start.Text = "Start Listen For HotKey";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(161, 109);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            900000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(145, 20);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 111);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Milliseconds Between Clicks:";
			// 
			// status
			// 
			this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.status.Location = new System.Drawing.Point(9, 211);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(370, 21);
			this.status.TabIndex = 3;
			this.status.Text = "Not Running...";
			this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// keys
			// 
			this.keys.Location = new System.Drawing.Point(161, 147);
			this.keys.Name = "keys";
			this.keys.Size = new System.Drawing.Size(221, 20);
			this.keys.TabIndex = 4;
			this.keys.Text = "123457869";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Keys to press:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Milliseconds Between Keys:";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(161, 179);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            900000,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(145, 20);
			this.numericUpDown2.TabIndex = 6;
			this.numericUpDown2.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			// 
			// handleImage
			// 
			this.handleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.handleImage.Image = global::MouseClicker.Properties.Resources.Crosshair_16xLG;
			this.handleImage.Location = new System.Drawing.Point(14, 56);
			this.handleImage.Margin = new System.Windows.Forms.Padding(5);
			this.handleImage.Name = "handleImage";
			this.handleImage.Size = new System.Drawing.Size(24, 24);
			this.handleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.handleImage.TabIndex = 8;
			this.handleImage.TabStop = false;
			this.handleImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.handleImage_MouseDown);
			this.handleImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.handleImage_MouseMove);
			this.handleImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.handleImage_MouseUp);
			// 
			// target
			// 
			this.target.AutoSize = true;
			this.target.Location = new System.Drawing.Point(46, 63);
			this.target.Name = "target";
			this.target.Size = new System.Drawing.Size(44, 13);
			this.target.TabIndex = 10;
			this.target.Text = "[Target]";
			this.target.Visible = false;
			// 
			// enableClick
			// 
			this.enableClick.AutoSize = true;
			this.enableClick.Checked = true;
			this.enableClick.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enableClick.Location = new System.Drawing.Point(12, 89);
			this.enableClick.Name = "enableClick";
			this.enableClick.Size = new System.Drawing.Size(90, 17);
			this.enableClick.TabIndex = 11;
			this.enableClick.Text = "Enable Clicks";
			this.enableClick.UseVisualStyleBackColor = true;
			// 
			// reset
			// 
			this.reset.Enabled = false;
			this.reset.Location = new System.Drawing.Point(161, 56);
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(75, 23);
			this.reset.TabIndex = 12;
			this.reset.Text = "Reset";
			this.reset.UseVisualStyleBackColor = true;
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// enableKeys
			// 
			this.enableKeys.AutoSize = true;
			this.enableKeys.Checked = true;
			this.enableKeys.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enableKeys.Location = new System.Drawing.Point(12, 127);
			this.enableKeys.Name = "enableKeys";
			this.enableKeys.Size = new System.Drawing.Size(105, 17);
			this.enableKeys.TabIndex = 13;
			this.enableKeys.Text = "Enable Keypress";
			this.enableKeys.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 241);
			this.Controls.Add(this.enableKeys);
			this.Controls.Add(this.reset);
			this.Controls.Add(this.enableClick);
			this.Controls.Add(this.target);
			this.Controls.Add(this.handleImage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.keys);
			this.Controls.Add(this.status);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.start);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(410, 280);
			this.MinimumSize = new System.Drawing.Size(410, 280);
			this.Name = "Form1";
			this.Text = "Mouse Clickr";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.handleImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button start;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.TextBox keys;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.PictureBox handleImage;
		private System.Windows.Forms.Label target;
		private System.Windows.Forms.CheckBox enableClick;
		private System.Windows.Forms.Button reset;
		private System.Windows.Forms.CheckBox enableKeys;
	}
}

