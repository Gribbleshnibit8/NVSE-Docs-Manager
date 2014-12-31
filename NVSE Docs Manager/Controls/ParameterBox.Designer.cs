namespace NVSE_Docs_Manager.Controls
{
	partial class ParameterBox
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxParameter = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxParameterValue = new System.Windows.Forms.ComboBox();
			this.labelParameterTemplateName = new System.Windows.Forms.Label();
			this.buttonParameterTemplateRemove = new System.Windows.Forms.Button();
			this.comboBoxParameterName = new System.Windows.Forms.ComboBox();
			this.comboBoxParameterType = new System.Windows.Forms.ComboBox();
			this.checkBoxParameterTemplateOptional = new System.Windows.Forms.CheckBox();
			this.labelParameterTemplateType = new System.Windows.Forms.Label();
			this.labelParameterTemplateURL = new System.Windows.Forms.Label();
			this.comboBoxParameterURL = new System.Windows.Forms.ComboBox();
			this.groupBoxParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxParameter
			// 
			this.groupBoxParameter.Controls.Add(this.button1);
			this.groupBoxParameter.Controls.Add(this.label1);
			this.groupBoxParameter.Controls.Add(this.comboBoxParameterValue);
			this.groupBoxParameter.Controls.Add(this.labelParameterTemplateName);
			this.groupBoxParameter.Controls.Add(this.buttonParameterTemplateRemove);
			this.groupBoxParameter.Controls.Add(this.comboBoxParameterName);
			this.groupBoxParameter.Controls.Add(this.comboBoxParameterType);
			this.groupBoxParameter.Controls.Add(this.checkBoxParameterTemplateOptional);
			this.groupBoxParameter.Controls.Add(this.labelParameterTemplateType);
			this.groupBoxParameter.Controls.Add(this.labelParameterTemplateURL);
			this.groupBoxParameter.Controls.Add(this.comboBoxParameterURL);
			this.groupBoxParameter.Location = new System.Drawing.Point(0, 0);
			this.groupBoxParameter.Name = "groupBoxParameter";
			this.groupBoxParameter.Size = new System.Drawing.Size(435, 70);
			this.groupBoxParameter.TabIndex = 32;
			this.groupBoxParameter.TabStop = false;
			this.groupBoxParameter.Text = "ParameterBox 1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(30, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 21);
			this.button1.TabIndex = 33;
			this.button1.Text = "C";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CopyParameter_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(243, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Value";
			// 
			// comboBoxParameterValue
			// 
			this.comboBoxParameterValue.FormattingEnabled = true;
			this.comboBoxParameterValue.Location = new System.Drawing.Point(283, 13);
			this.comboBoxParameterValue.Name = "comboBoxParameterValue";
			this.comboBoxParameterValue.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterValue.TabIndex = 31;
			this.comboBoxParameterValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ValueBox_KeyUp);
			// 
			// labelParameterTemplateName
			// 
			this.labelParameterTemplateName.AutoSize = true;
			this.labelParameterTemplateName.Location = new System.Drawing.Point(243, 43);
			this.labelParameterTemplateName.Name = "labelParameterTemplateName";
			this.labelParameterTemplateName.Size = new System.Drawing.Size(35, 13);
			this.labelParameterTemplateName.TabIndex = 29;
			this.labelParameterTemplateName.Text = "Name";
			// 
			// buttonParameterTemplateRemove
			// 
			this.buttonParameterTemplateRemove.Location = new System.Drawing.Point(5, 13);
			this.buttonParameterTemplateRemove.Name = "buttonParameterTemplateRemove";
			this.buttonParameterTemplateRemove.Size = new System.Drawing.Size(23, 21);
			this.buttonParameterTemplateRemove.TabIndex = 28;
			this.buttonParameterTemplateRemove.Text = "X";
			this.buttonParameterTemplateRemove.UseVisualStyleBackColor = true;
			this.buttonParameterTemplateRemove.Click += new System.EventHandler(this.RemoveParameter_Click);
			// 
			// comboBoxParameterName
			// 
			this.comboBoxParameterName.FormattingEnabled = true;
			this.comboBoxParameterName.Location = new System.Drawing.Point(284, 40);
			this.comboBoxParameterName.Name = "comboBoxParameterName";
			this.comboBoxParameterName.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterName.TabIndex = 30;
			this.comboBoxParameterName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NameBox_KeyUp);
			// 
			// comboBoxParameterType
			// 
			this.comboBoxParameterType.FormattingEnabled = true;
			this.comboBoxParameterType.Location = new System.Drawing.Point(96, 40);
			this.comboBoxParameterType.Name = "comboBoxParameterType";
			this.comboBoxParameterType.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterType.TabIndex = 3;
			this.comboBoxParameterType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TypeBox_KeyUp);
			// 
			// checkBoxParameterTemplateOptional
			// 
			this.checkBoxParameterTemplateOptional.AutoSize = true;
			this.checkBoxParameterTemplateOptional.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxParameterTemplateOptional.Location = new System.Drawing.Point(6, 35);
			this.checkBoxParameterTemplateOptional.Name = "checkBoxParameterTemplateOptional";
			this.checkBoxParameterTemplateOptional.Size = new System.Drawing.Size(50, 31);
			this.checkBoxParameterTemplateOptional.TabIndex = 1;
			this.checkBoxParameterTemplateOptional.Text = "Optional";
			this.checkBoxParameterTemplateOptional.UseVisualStyleBackColor = true;
			this.checkBoxParameterTemplateOptional.CheckedChanged += new System.EventHandler(this.OptionalBox_CheckedChanged);
			// 
			// labelParameterTemplateType
			// 
			this.labelParameterTemplateType.AutoSize = true;
			this.labelParameterTemplateType.Location = new System.Drawing.Point(59, 43);
			this.labelParameterTemplateType.Name = "labelParameterTemplateType";
			this.labelParameterTemplateType.Size = new System.Drawing.Size(31, 13);
			this.labelParameterTemplateType.TabIndex = 2;
			this.labelParameterTemplateType.Text = "Type";
			// 
			// labelParameterTemplateURL
			// 
			this.labelParameterTemplateURL.AutoSize = true;
			this.labelParameterTemplateURL.Location = new System.Drawing.Point(59, 16);
			this.labelParameterTemplateURL.Name = "labelParameterTemplateURL";
			this.labelParameterTemplateURL.Size = new System.Drawing.Size(29, 13);
			this.labelParameterTemplateURL.TabIndex = 0;
			this.labelParameterTemplateURL.Text = "URL";
			// 
			// comboBoxParameterURL
			// 
			this.comboBoxParameterURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxParameterURL.FormattingEnabled = true;
			this.comboBoxParameterURL.Items.AddRange(new object[] {
            "Actor_Flags",
            "Actor_Value_Codes",
            "Attack_Animations",
            "Biped_Path_Codes",
            "Control_Codes",
            "DirectX_Scancodes",
            "Equip_Type",
            "Equipment_Slot_IDs",
            "Form_Type_IDs",
            "Reload_Animations",
            "Weapon_Flags",
            "Weapon_Hand_Grips",
            "Weapon_Mod",
            "Weapon_Type"});
			this.comboBoxParameterURL.Location = new System.Drawing.Point(97, 13);
			this.comboBoxParameterURL.Name = "comboBoxParameterURL";
			this.comboBoxParameterURL.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterURL.Sorted = true;
			this.comboBoxParameterURL.TabIndex = 1;
			this.comboBoxParameterURL.SelectedIndexChanged += new System.EventHandler(this.UrlBox_SelectedIndexChanged);
			// 
			// ParameterBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.groupBoxParameter);
			this.Size = new System.Drawing.Size(438, 73);
			this.groupBoxParameter.ResumeLayout(false);
			this.groupBoxParameter.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxParameter;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxParameterValue;
		private System.Windows.Forms.Label labelParameterTemplateName;
		private System.Windows.Forms.Button buttonParameterTemplateRemove;
		private System.Windows.Forms.ComboBox comboBoxParameterName;
		private System.Windows.Forms.ComboBox comboBoxParameterType;
		private System.Windows.Forms.CheckBox checkBoxParameterTemplateOptional;
		private System.Windows.Forms.Label labelParameterTemplateType;
		private System.Windows.Forms.Label labelParameterTemplateURL;
		private System.Windows.Forms.ComboBox comboBoxParameterURL;
	}
}
