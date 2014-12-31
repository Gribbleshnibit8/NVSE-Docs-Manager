namespace NVSE_Docs_Manager.Windows
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
			this.components = new System.ComponentModel.Container();
			this.listBoxExamples = new System.Windows.Forms.ListBox();
			this.richTextBoxExampleEditor = new System.Windows.Forms.RichTextBox();
			this.buttonAddExample = new System.Windows.Forms.Button();
			this.buttonDone = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// listBoxExamples
			// 
			this.listBoxExamples.FormattingEnabled = true;
			this.listBoxExamples.Location = new System.Drawing.Point(12, 12);
			this.listBoxExamples.Name = "listBoxExamples";
			this.listBoxExamples.ScrollAlwaysVisible = true;
			this.listBoxExamples.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxExamples.Size = new System.Drawing.Size(135, 147);
			this.listBoxExamples.TabIndex = 0;
			this.toolTip1.SetToolTip(this.listBoxExamples, "Click an example to edit");
			this.listBoxExamples.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxExamples_MouseClick);
			this.listBoxExamples.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listboxExamples_KeyUp);
			// 
			// richTextBoxExampleEditor
			// 
			this.richTextBoxExampleEditor.AcceptsTab = true;
			this.richTextBoxExampleEditor.EnableAutoDragDrop = true;
			this.richTextBoxExampleEditor.Enabled = false;
			this.richTextBoxExampleEditor.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxExampleEditor.Location = new System.Drawing.Point(153, 12);
			this.richTextBoxExampleEditor.Name = "richTextBoxExampleEditor";
			this.richTextBoxExampleEditor.Size = new System.Drawing.Size(619, 342);
			this.richTextBoxExampleEditor.TabIndex = 1;
			this.richTextBoxExampleEditor.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxExampleEditor, "Type the example here");
			this.richTextBoxExampleEditor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ExampleEditor_KeyUp);
			// 
			// buttonAddExample
			// 
			this.buttonAddExample.Location = new System.Drawing.Point(12, 165);
			this.buttonAddExample.Name = "buttonAddExample";
			this.buttonAddExample.Size = new System.Drawing.Size(135, 47);
			this.buttonAddExample.TabIndex = 2;
			this.buttonAddExample.Text = "Add Example";
			this.toolTip1.SetToolTip(this.buttonAddExample, "Add a new example");
			this.buttonAddExample.UseVisualStyleBackColor = true;
			this.buttonAddExample.Click += new System.EventHandler(this.buttonAddExample_Click);
			// 
			// buttonDone
			// 
			this.buttonDone.Location = new System.Drawing.Point(12, 326);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(135, 28);
			this.buttonDone.TabIndex = 3;
			this.buttonDone.Text = "Done";
			this.toolTip1.SetToolTip(this.buttonDone, "Finished editing, close this window");
			this.buttonDone.UseVisualStyleBackColor = true;
			this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 100;
			this.toolTip1.ReshowDelay = 100;
			// 
			// ExamplesWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 366);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.buttonAddExample);
			this.Controls.Add(this.richTextBoxExampleEditor);
			this.Controls.Add(this.listBoxExamples);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ExamplesWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ExamplesWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxExamples;
		private System.Windows.Forms.RichTextBox richTextBoxExampleEditor;
		private System.Windows.Forms.Button buttonAddExample;
		private System.Windows.Forms.Button buttonDone;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}