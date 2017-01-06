namespace AlwaysOnTop.Classes
{
	partial class FormSetHotkey
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetHotkey));
			this.txtHotkey = new System.Windows.Forms.TextBox();
			this.btnSetKey = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtHotkey
			// 
			this.txtHotkey.Cursor = System.Windows.Forms.Cursors.Default;
			this.txtHotkey.Enabled = false;
			this.txtHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHotkey.Location = new System.Drawing.Point(12, 57);
			this.txtHotkey.Name = "txtHotkey";
			this.txtHotkey.Size = new System.Drawing.Size(195, 24);
			this.txtHotkey.TabIndex = 0;
			this.txtHotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnSetKey
			// 
			this.btnSetKey.Location = new System.Drawing.Point(280, 59);
			this.btnSetKey.Name = "btnSetKey";
			this.btnSetKey.Size = new System.Drawing.Size(75, 23);
			this.btnSetKey.TabIndex = 1;
			this.btnSetKey.Text = "Set Hotkey";
			this.btnSetKey.UseVisualStyleBackColor = true;
			this.btnSetKey.Click += new System.EventHandler(this.btnSetKey_Click);
			this.btnSetKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetHotkey_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 9);
			this.label1.MaximumSize = new System.Drawing.Size(300, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(285, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = "Click the \"Set Hotkey\" button, then press your desired key combination";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(49, 121);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 13);
			this.label9.TabIndex = 23;
			this.label9.Text = "All Rights Reserved";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(2, 108);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(195, 13);
			this.label8.TabIndex = 22;
			this.label8.Text = "Copyright © 2013 - 2016 Joshua Parnell";
			// 
			// btnApply
			// 
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(203, 111);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 24;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(284, 111);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 25;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnClose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetHotkey_KeyUp);
			// 
			// FormSetHotkey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 145);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSetKey);
			this.Controls.Add(this.txtHotkey);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormSetHotkey";
			this.Text = "AlwaysOnTop - Set Hotkey Preference";
			this.Load += new System.EventHandler(this.FormSetHotkey_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetHotkey_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtHotkey;
		private System.Windows.Forms.Button btnSetKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnClose;
	}
}