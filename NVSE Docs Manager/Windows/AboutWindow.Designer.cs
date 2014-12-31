namespace NVSE_Docs_Manager.Windows
{
	partial class AboutWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(375, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "NVSE Docs Manager is a utility for creating and editing json files for the NVSE F" +
    "unctions Guide at:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(12, 37);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(255, 13);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.gribbleshnibit.com/projects/NVSEDocs/";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(375, 143);
			this.label2.TabIndex = 2;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(15, 238);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(199, 13);
			this.linkLabel2.TabIndex = 3;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "http://opensource.org/licenses/GPL-3.0";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Copyright 2014";
			// 
			// AboutWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 264);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AboutWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Load += new System.EventHandler(this.AboutWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.Label label3;
	}
}