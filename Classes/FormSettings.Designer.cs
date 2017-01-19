namespace AlwaysOnTop.Classes
{
	partial class FormSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.chkRunAtLogin = new System.Windows.Forms.CheckBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.chkTitleContext = new System.Windows.Forms.CheckBox();
			this.chkHotKey = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.chkPermWindows = new System.Windows.Forms.CheckBox();
			this.listPermWindows = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSelectWindows = new System.Windows.Forms.Button();
			this.btnSetHotkey = new System.Windows.Forms.Button();
			this.chkDisableBalloonNotify = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkRunAtLogin
			// 
			this.chkRunAtLogin.AutoSize = true;
			this.chkRunAtLogin.Location = new System.Drawing.Point(12, 12);
			this.chkRunAtLogin.Name = "chkRunAtLogin";
			this.chkRunAtLogin.Size = new System.Drawing.Size(152, 17);
			this.chkRunAtLogin.TabIndex = 0;
			this.chkRunAtLogin.Text = "Run AlwaysOnTop at login";
			this.chkRunAtLogin.UseVisualStyleBackColor = true;
			this.chkRunAtLogin.CheckedChanged += new System.EventHandler(this.chkRunAtLogin_CheckedChanged);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(364, 190);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(283, 190);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// chkTitleContext
			// 
			this.chkTitleContext.AutoSize = true;
			this.chkTitleContext.Location = new System.Drawing.Point(197, 12);
			this.chkTitleContext.Name = "chkTitleContext";
			this.chkTitleContext.Size = new System.Drawing.Size(164, 17);
			this.chkTitleContext.TabIndex = 3;
			this.chkTitleContext.Text = "Use Windows System Menus";
			this.chkTitleContext.UseVisualStyleBackColor = true;
			this.chkTitleContext.CheckedChanged += new System.EventHandler(this.chkTitleContext_CheckedChanged);
			// 
			// chkHotKey
			// 
			this.chkHotKey.AutoSize = true;
			this.chkHotKey.Location = new System.Drawing.Point(12, 35);
			this.chkHotKey.Name = "chkHotKey";
			this.chkHotKey.Size = new System.Drawing.Size(92, 17);
			this.chkHotKey.TabIndex = 4;
			this.chkHotKey.Text = "Use A Hotkey";
			this.chkHotKey.UseVisualStyleBackColor = true;
			this.chkHotKey.CheckedChanged += new System.EventHandler(this.chkHotKey_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.DarkRed;
			this.label2.Location = new System.Drawing.Point(364, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Coming soon!";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(64, 200);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "All Rights Reserved";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 187);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(195, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Copyright © 2013 - 2016 Joshua Parnell";
			// 
			// chkPermWindows
			// 
			this.chkPermWindows.AutoSize = true;
			this.chkPermWindows.Location = new System.Drawing.Point(12, 58);
			this.chkPermWindows.Name = "chkPermWindows";
			this.chkPermWindows.Size = new System.Drawing.Size(186, 17);
			this.chkPermWindows.TabIndex = 22;
			this.chkPermWindows.Text = "Always put these windows on top:";
			this.chkPermWindows.UseVisualStyleBackColor = true;
			this.chkPermWindows.CheckedChanged += new System.EventHandler(this.chkPermWindows_CheckedChanged);
			// 
			// listPermWindows
			// 
			this.listPermWindows.FormattingEnabled = true;
			this.listPermWindows.Location = new System.Drawing.Point(12, 81);
			this.listPermWindows.Name = "listPermWindows";
			this.listPermWindows.Size = new System.Drawing.Size(427, 95);
			this.listPermWindows.TabIndex = 23;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DarkRed;
			this.label3.Location = new System.Drawing.Point(204, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Coming soon!";
			// 
			// btnSelectWindows
			// 
			this.btnSelectWindows.Location = new System.Drawing.Point(345, 54);
			this.btnSelectWindows.Name = "btnSelectWindows";
			this.btnSelectWindows.Size = new System.Drawing.Size(94, 23);
			this.btnSelectWindows.TabIndex = 25;
			this.btnSelectWindows.Text = "Select Windows";
			this.btnSelectWindows.UseVisualStyleBackColor = true;
			this.btnSelectWindows.Click += new System.EventHandler(this.btnSelectWindows_Click);
			// 
			// btnSetHotkey
			// 
			this.btnSetHotkey.Location = new System.Drawing.Point(110, 31);
			this.btnSetHotkey.Name = "btnSetHotkey";
			this.btnSetHotkey.Size = new System.Drawing.Size(75, 23);
			this.btnSetHotkey.TabIndex = 26;
			this.btnSetHotkey.Text = "Set Hotkey";
			this.btnSetHotkey.UseVisualStyleBackColor = true;
			this.btnSetHotkey.Click += new System.EventHandler(this.btnSetHotkey_Click);
			// 
			// chkDisableBalloonNotify
			// 
			this.chkDisableBalloonNotify.AutoSize = true;
			this.chkDisableBalloonNotify.Location = new System.Drawing.Point(197, 35);
			this.chkDisableBalloonNotify.Name = "chkDisableBalloonNotify";
			this.chkDisableBalloonNotify.Size = new System.Drawing.Size(178, 17);
			this.chkDisableBalloonNotify.TabIndex = 27;
			this.chkDisableBalloonNotify.Text = "Disable Balloon Tip Notifications";
			this.chkDisableBalloonNotify.UseVisualStyleBackColor = true;
			this.chkDisableBalloonNotify.CheckedChanged += new System.EventHandler(this.chkDisableBalloonNotify_CheckedChanged);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 222);
			this.Controls.Add(this.chkDisableBalloonNotify);
			this.Controls.Add(this.btnSetHotkey);
			this.Controls.Add(this.btnSelectWindows);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listPermWindows);
			this.Controls.Add(this.chkPermWindows);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkHotKey);
			this.Controls.Add(this.chkTitleContext);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.chkRunAtLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormSettings";
			this.Text = "AlwaysOnTop - Settings";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkRunAtLogin;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.CheckBox chkTitleContext;
		private System.Windows.Forms.CheckBox chkHotKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkPermWindows;
		private System.Windows.Forms.ListBox listPermWindows;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSelectWindows;
		private System.Windows.Forms.Button btnSetHotkey;
		private System.Windows.Forms.CheckBox chkDisableBalloonNotify;
	}
}