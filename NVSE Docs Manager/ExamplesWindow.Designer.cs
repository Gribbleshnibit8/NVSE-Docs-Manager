namespace NVSE_Docs_Manager
{
	partial class ExamplesWindow
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.buttonAddExample = new System.Windows.Forms.Button();
			this.buttonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Items.AddRange(new object[] {
            "Example 1",
            "Example 2"});
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(135, 108);
			this.listBox1.TabIndex = 0;
			// 
			// richTextBox1
			// 
			this.richTextBox1.AcceptsTab = true;
			this.richTextBox1.EnableAutoDragDrop = true;
			this.richTextBox1.Location = new System.Drawing.Point(153, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(469, 288);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// buttonAddExample
			// 
			this.buttonAddExample.Location = new System.Drawing.Point(12, 126);
			this.buttonAddExample.Name = "buttonAddExample";
			this.buttonAddExample.Size = new System.Drawing.Size(135, 47);
			this.buttonAddExample.TabIndex = 2;
			this.buttonAddExample.Text = "Add Example";
			this.buttonAddExample.UseVisualStyleBackColor = true;
			// 
			// buttonDone
			// 
			this.buttonDone.Location = new System.Drawing.Point(12, 272);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(135, 28);
			this.buttonDone.TabIndex = 3;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			// 
			// ExamplesWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 312);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.buttonAddExample);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ExamplesWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ExamplesWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button buttonAddExample;
		private System.Windows.Forms.Button buttonDone;
	}
}