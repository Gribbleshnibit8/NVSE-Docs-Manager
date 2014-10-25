namespace NVSE_Docs_Manager
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>/// <summary>
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.listboxFunctionList = new System.Windows.Forms.ListBox();
			this.groupSelectionEditor = new System.Windows.Forms.GroupBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
			this.buttonNewFunction = new System.Windows.Forms.Button();
			this.groupBoxReturnType = new System.Windows.Forms.GroupBox();
			this.checkBoxReturnType = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxReturnTypeURL = new System.Windows.Forms.ComboBox();
			this.comboBoxReturnTypeType = new System.Windows.Forms.ComboBox();
			this.buttonDiscardChanges = new System.Windows.Forms.Button();
			this.buttonSaveCurrentChanges = new System.Windows.Forms.Button();
			this.flowLayoutPanelParameters = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBoxParameterTemplate = new System.Windows.Forms.GroupBox();
			this.labelParameterTemplateName = new System.Windows.Forms.Label();
			this.comboBoxParameterTemplateName = new System.Windows.Forms.ComboBox();
			this.buttonParameterTemplateRemove = new System.Windows.Forms.Button();
			this.checkBoxParameterTemplateOptional = new System.Windows.Forms.CheckBox();
			this.labelParameterTemplateURL = new System.Windows.Forms.Label();
			this.labelParameterTemplateType = new System.Windows.Forms.Label();
			this.comboBoxParameterTemplateURL = new System.Windows.Forms.ComboBox();
			this.comboBoxParameterTemplateType = new System.Windows.Forms.ComboBox();
			this.buttonParameterCopy = new System.Windows.Forms.Button();
			this.buttonParametersNew = new System.Windows.Forms.Button();
			this.textBoxCategory = new System.Windows.Forms.TextBox();
			this.labelCategory = new System.Windows.Forms.Label();
			this.textBoxOrigin = new System.Windows.Forms.TextBox();
			this.labelOrigin = new System.Windows.Forms.Label();
			this.labelTags = new System.Windows.Forms.Label();
			this.textBoxTags = new System.Windows.Forms.TextBox();
			this.labelReturnType = new System.Windows.Forms.Label();
			this.labelParameters = new System.Windows.Forms.Label();
			this.groupBoxCallingConvention = new System.Windows.Forms.GroupBox();
			this.radioButtonCallingConventionEither = new System.Windows.Forms.RadioButton();
			this.radioButtonCallingConventionBase = new System.Windows.Forms.RadioButton();
			this.radioButtonCallingConventionRef = new System.Windows.Forms.RadioButton();
			this.labelVersion = new System.Windows.Forms.Label();
			this.textBoxVersion = new System.Windows.Forms.TextBox();
			this.textBoxAlias = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelAlias = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.checkBoxConditional = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonListBoxDeleteItem = new System.Windows.Forms.Button();
			this.buttonListBoxChangeCategory = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupSelectionEditor.SuspendLayout();
			this.groupBoxReturnType.SuspendLayout();
			this.flowLayoutPanelParameters.SuspendLayout();
			this.groupBoxParameterTemplate.SuspendLayout();
			this.groupBoxCallingConvention.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1075, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "mainMenu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.resetEverythingToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openFileToolStripMenuItem
			// 
			this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
			this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.openFileToolStripMenuItem.Text = "Open File";
			this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
			// 
			// saveFileToolStripMenuItem
			// 
			this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
			this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.saveFileToolStripMenuItem.Text = "Save File";
			this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
			// 
			// resetEverythingToolStripMenuItem
			// 
			this.resetEverythingToolStripMenuItem.Name = "resetEverythingToolStripMenuItem";
			this.resetEverythingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.L)));
			this.resetEverythingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.resetEverythingToolStripMenuItem.Text = "Clear List";
			this.resetEverythingToolStripMenuItem.Click += new System.EventHandler(this.resetEverythingToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 655);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1075, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// listboxFunctionList
			// 
			this.listboxFunctionList.AllowDrop = true;
			this.listboxFunctionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listboxFunctionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listboxFunctionList.FormattingEnabled = true;
			this.listboxFunctionList.ItemHeight = 16;
			this.listboxFunctionList.Location = new System.Drawing.Point(12, 36);
			this.listboxFunctionList.Name = "listboxFunctionList";
			this.listboxFunctionList.ScrollAlwaysVisible = true;
			this.listboxFunctionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listboxFunctionList.Size = new System.Drawing.Size(300, 580);
			this.listboxFunctionList.Sorted = true;
			this.listboxFunctionList.TabIndex = 1;
			this.listboxFunctionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listboxFunctionList_MouseDoubleClick);
			this.listboxFunctionList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listboxFunctionList_MouseUp);
			// 
			// groupSelectionEditor
			// 
			this.groupSelectionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupSelectionEditor.Controls.Add(this.labelDescription);
			this.groupSelectionEditor.Controls.Add(this.richTextBoxDescription);
			this.groupSelectionEditor.Controls.Add(this.buttonNewFunction);
			this.groupSelectionEditor.Controls.Add(this.groupBoxReturnType);
			this.groupSelectionEditor.Controls.Add(this.buttonDiscardChanges);
			this.groupSelectionEditor.Controls.Add(this.buttonSaveCurrentChanges);
			this.groupSelectionEditor.Controls.Add(this.flowLayoutPanelParameters);
			this.groupSelectionEditor.Controls.Add(this.buttonParameterCopy);
			this.groupSelectionEditor.Controls.Add(this.buttonParametersNew);
			this.groupSelectionEditor.Controls.Add(this.textBoxCategory);
			this.groupSelectionEditor.Controls.Add(this.labelCategory);
			this.groupSelectionEditor.Controls.Add(this.textBoxOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelTags);
			this.groupSelectionEditor.Controls.Add(this.textBoxTags);
			this.groupSelectionEditor.Controls.Add(this.labelReturnType);
			this.groupSelectionEditor.Controls.Add(this.labelParameters);
			this.groupSelectionEditor.Controls.Add(this.groupBoxCallingConvention);
			this.groupSelectionEditor.Controls.Add(this.labelVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxAlias);
			this.groupSelectionEditor.Controls.Add(this.textBoxName);
			this.groupSelectionEditor.Controls.Add(this.labelAlias);
			this.groupSelectionEditor.Controls.Add(this.labelName);
			this.groupSelectionEditor.Controls.Add(this.checkBoxConditional);
			this.groupSelectionEditor.Location = new System.Drawing.Point(318, 30);
			this.groupSelectionEditor.Name = "groupSelectionEditor";
			this.groupSelectionEditor.Size = new System.Drawing.Size(746, 612);
			this.groupSelectionEditor.TabIndex = 3;
			this.groupSelectionEditor.TabStop = false;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(187, 438);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(60, 13);
			this.labelDescription.TabIndex = 504;
			this.labelDescription.Text = "Description";
			// 
			// richTextBoxDescription
			// 
			this.richTextBoxDescription.AcceptsTab = true;
			this.richTextBoxDescription.Location = new System.Drawing.Point(190, 454);
			this.richTextBoxDescription.Name = "richTextBoxDescription";
			this.richTextBoxDescription.Size = new System.Drawing.Size(373, 152);
			this.richTextBoxDescription.TabIndex = 13;
			this.richTextBoxDescription.Text = "";
			this.richTextBoxDescription.ZoomFactor = 1.2F;
			// 
			// buttonNewFunction
			// 
			this.buttonNewFunction.Location = new System.Drawing.Point(107, 501);
			this.buttonNewFunction.Name = "buttonNewFunction";
			this.buttonNewFunction.Size = new System.Drawing.Size(59, 50);
			this.buttonNewFunction.TabIndex = 502;
			this.buttonNewFunction.Text = "New Function";
			this.buttonNewFunction.UseVisualStyleBackColor = true;
			this.buttonNewFunction.Click += new System.EventHandler(this.buttonNewFunction_Click);
			// 
			// groupBoxReturnType
			// 
			this.groupBoxReturnType.AutoSize = true;
			this.groupBoxReturnType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxReturnType.Controls.Add(this.checkBoxReturnType);
			this.groupBoxReturnType.Controls.Add(this.label3);
			this.groupBoxReturnType.Controls.Add(this.label5);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeURL);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeType);
			this.groupBoxReturnType.Location = new System.Drawing.Point(190, 369);
			this.groupBoxReturnType.Name = "groupBoxReturnType";
			this.groupBoxReturnType.Size = new System.Drawing.Size(373, 60);
			this.groupBoxReturnType.TabIndex = 12;
			this.groupBoxReturnType.TabStop = false;
			this.groupBoxReturnType.Text = "Return Type";
			// 
			// checkBoxReturnType
			// 
			this.checkBoxReturnType.AutoSize = true;
			this.checkBoxReturnType.Location = new System.Drawing.Point(6, 24);
			this.checkBoxReturnType.Name = "checkBoxReturnType";
			this.checkBoxReturnType.Size = new System.Drawing.Size(15, 14);
			this.checkBoxReturnType.TabIndex = 11;
			this.checkBoxReturnType.UseVisualStyleBackColor = true;
			this.checkBoxReturnType.CheckedChanged += new System.EventHandler(this.checkBoxReturnType_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Enabled = false;
			this.label3.Location = new System.Drawing.Point(28, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "URL";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Enabled = false;
			this.label5.Location = new System.Drawing.Point(192, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Type";
			// 
			// comboBoxReturnTypeURL
			// 
			this.comboBoxReturnTypeURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxReturnTypeURL.Enabled = false;
			this.comboBoxReturnTypeURL.FormattingEnabled = true;
			this.comboBoxReturnTypeURL.Items.AddRange(new object[] {
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
			this.comboBoxReturnTypeURL.Location = new System.Drawing.Point(64, 20);
			this.comboBoxReturnTypeURL.Name = "comboBoxReturnTypeURL";
			this.comboBoxReturnTypeURL.Size = new System.Drawing.Size(121, 21);
			this.comboBoxReturnTypeURL.Sorted = true;
			this.comboBoxReturnTypeURL.TabIndex = 1;
			// 
			// comboBoxReturnTypeType
			// 
			this.comboBoxReturnTypeType.Enabled = false;
			this.comboBoxReturnTypeType.FormattingEnabled = true;
			this.comboBoxReturnTypeType.Location = new System.Drawing.Point(230, 20);
			this.comboBoxReturnTypeType.Name = "comboBoxReturnTypeType";
			this.comboBoxReturnTypeType.Size = new System.Drawing.Size(137, 21);
			this.comboBoxReturnTypeType.TabIndex = 3;
			// 
			// buttonDiscardChanges
			// 
			this.buttonDiscardChanges.Location = new System.Drawing.Point(107, 556);
			this.buttonDiscardChanges.Name = "buttonDiscardChanges";
			this.buttonDiscardChanges.Size = new System.Drawing.Size(59, 50);
			this.buttonDiscardChanges.TabIndex = 501;
			this.buttonDiscardChanges.Text = " Discard Changes";
			this.buttonDiscardChanges.UseVisualStyleBackColor = true;
			this.buttonDiscardChanges.Click += new System.EventHandler(this.buttonDiscardChanges_Click);
			// 
			// buttonSaveCurrentChanges
			// 
			this.buttonSaveCurrentChanges.Enabled = false;
			this.buttonSaveCurrentChanges.Location = new System.Drawing.Point(9, 501);
			this.buttonSaveCurrentChanges.Name = "buttonSaveCurrentChanges";
			this.buttonSaveCurrentChanges.Size = new System.Drawing.Size(92, 105);
			this.buttonSaveCurrentChanges.TabIndex = 500;
			this.buttonSaveCurrentChanges.Text = "Save\r\nChanges";
			this.buttonSaveCurrentChanges.UseVisualStyleBackColor = true;
			this.buttonSaveCurrentChanges.Click += new System.EventHandler(this.buttonSaveCurrentChanges_Click);
			// 
			// flowLayoutPanelParameters
			// 
			this.flowLayoutPanelParameters.AutoScroll = true;
			this.flowLayoutPanelParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flowLayoutPanelParameters.Controls.Add(this.groupBoxParameterTemplate);
			this.flowLayoutPanelParameters.Location = new System.Drawing.Point(190, 35);
			this.flowLayoutPanelParameters.Name = "flowLayoutPanelParameters";
			this.flowLayoutPanelParameters.Size = new System.Drawing.Size(550, 328);
			this.flowLayoutPanelParameters.TabIndex = 11;
			// 
			// groupBoxParameterTemplate
			// 
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateName);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateName);
			this.groupBoxParameterTemplate.Controls.Add(this.buttonParameterTemplateRemove);
			this.groupBoxParameterTemplate.Controls.Add(this.checkBoxParameterTemplateOptional);
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateURL);
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateType);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateURL);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateType);
			this.groupBoxParameterTemplate.Location = new System.Drawing.Point(3, 3);
			this.groupBoxParameterTemplate.Name = "groupBoxParameterTemplate";
			this.groupBoxParameterTemplate.Size = new System.Drawing.Size(525, 59);
			this.groupBoxParameterTemplate.TabIndex = 31;
			this.groupBoxParameterTemplate.TabStop = false;
			this.groupBoxParameterTemplate.Text = "Parameter 1";
			this.groupBoxParameterTemplate.Visible = false;
			// 
			// labelParameterTemplateName
			// 
			this.labelParameterTemplateName.AutoSize = true;
			this.labelParameterTemplateName.Location = new System.Drawing.Point(325, 16);
			this.labelParameterTemplateName.Name = "labelParameterTemplateName";
			this.labelParameterTemplateName.Size = new System.Drawing.Size(35, 13);
			this.labelParameterTemplateName.TabIndex = 29;
			this.labelParameterTemplateName.Text = "Name";
			// 
			// comboBoxParameterTemplateName
			// 
			this.comboBoxParameterTemplateName.FormattingEnabled = true;
			this.comboBoxParameterTemplateName.Location = new System.Drawing.Point(328, 32);
			this.comboBoxParameterTemplateName.Name = "comboBoxParameterTemplateName";
			this.comboBoxParameterTemplateName.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateName.TabIndex = 30;
			// 
			// buttonParameterTemplateRemove
			// 
			this.buttonParameterTemplateRemove.Location = new System.Drawing.Point(6, 16);
			this.buttonParameterTemplateRemove.Name = "buttonParameterTemplateRemove";
			this.buttonParameterTemplateRemove.Size = new System.Drawing.Size(24, 37);
			this.buttonParameterTemplateRemove.TabIndex = 28;
			this.buttonParameterTemplateRemove.Text = "X";
			this.buttonParameterTemplateRemove.UseVisualStyleBackColor = true;
			// 
			// checkBoxParameterTemplateOptional
			// 
			this.checkBoxParameterTemplateOptional.AutoSize = true;
			this.checkBoxParameterTemplateOptional.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxParameterTemplateOptional.Location = new System.Drawing.Point(469, 16);
			this.checkBoxParameterTemplateOptional.Name = "checkBoxParameterTemplateOptional";
			this.checkBoxParameterTemplateOptional.Size = new System.Drawing.Size(50, 31);
			this.checkBoxParameterTemplateOptional.TabIndex = 1;
			this.checkBoxParameterTemplateOptional.Text = "Optional";
			this.checkBoxParameterTemplateOptional.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.checkBoxParameterTemplateOptional.UseVisualStyleBackColor = true;
			// 
			// labelParameterTemplateURL
			// 
			this.labelParameterTemplateURL.AutoSize = true;
			this.labelParameterTemplateURL.Location = new System.Drawing.Point(33, 16);
			this.labelParameterTemplateURL.Name = "labelParameterTemplateURL";
			this.labelParameterTemplateURL.Size = new System.Drawing.Size(32, 13);
			this.labelParameterTemplateURL.TabIndex = 0;
			this.labelParameterTemplateURL.Text = "URL:";
			// 
			// labelParameterTemplateType
			// 
			this.labelParameterTemplateType.AutoSize = true;
			this.labelParameterTemplateType.Location = new System.Drawing.Point(179, 16);
			this.labelParameterTemplateType.Name = "labelParameterTemplateType";
			this.labelParameterTemplateType.Size = new System.Drawing.Size(31, 13);
			this.labelParameterTemplateType.TabIndex = 2;
			this.labelParameterTemplateType.Text = "Type";
			// 
			// comboBoxParameterTemplateURL
			// 
			this.comboBoxParameterTemplateURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxParameterTemplateURL.FormattingEnabled = true;
			this.comboBoxParameterTemplateURL.Items.AddRange(new object[] {
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
			this.comboBoxParameterTemplateURL.Location = new System.Drawing.Point(36, 32);
			this.comboBoxParameterTemplateURL.Name = "comboBoxParameterTemplateURL";
			this.comboBoxParameterTemplateURL.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateURL.Sorted = true;
			this.comboBoxParameterTemplateURL.TabIndex = 1;
			// 
			// comboBoxParameterTemplateType
			// 
			this.comboBoxParameterTemplateType.FormattingEnabled = true;
			this.comboBoxParameterTemplateType.Location = new System.Drawing.Point(182, 32);
			this.comboBoxParameterTemplateType.Name = "comboBoxParameterTemplateType";
			this.comboBoxParameterTemplateType.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateType.TabIndex = 3;
			// 
			// buttonParameterCopy
			// 
			this.buttonParameterCopy.AutoSize = true;
			this.buttonParameterCopy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonParameterCopy.Location = new System.Drawing.Point(349, 11);
			this.buttonParameterCopy.Name = "buttonParameterCopy";
			this.buttonParameterCopy.Size = new System.Drawing.Size(64, 23);
			this.buttonParameterCopy.TabIndex = 11;
			this.buttonParameterCopy.TabStop = false;
			this.buttonParameterCopy.Text = "Copy Last";
			this.buttonParameterCopy.UseVisualStyleBackColor = true;
			this.buttonParameterCopy.Click += new System.EventHandler(this.buttonCopyParameter_Click);
			// 
			// buttonParametersNew
			// 
			this.buttonParametersNew.AutoSize = true;
			this.buttonParametersNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonParametersNew.Location = new System.Drawing.Point(253, 11);
			this.buttonParametersNew.Name = "buttonParametersNew";
			this.buttonParametersNew.Size = new System.Drawing.Size(90, 23);
			this.buttonParametersNew.TabIndex = 10;
			this.buttonParametersNew.Text = "New Parameter";
			this.buttonParametersNew.UseVisualStyleBackColor = true;
			this.buttonParametersNew.Click += new System.EventHandler(this.buttonNewParameter_Click);
			// 
			// textBoxCategory
			// 
			this.textBoxCategory.Location = new System.Drawing.Point(9, 418);
			this.textBoxCategory.Name = "textBoxCategory";
			this.textBoxCategory.Size = new System.Drawing.Size(158, 20);
			this.textBoxCategory.TabIndex = 9;
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(6, 402);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(49, 13);
			this.labelCategory.TabIndex = 25;
			this.labelCategory.Text = "Category";
			// 
			// textBoxOrigin
			// 
			this.textBoxOrigin.Location = new System.Drawing.Point(9, 373);
			this.textBoxOrigin.Name = "textBoxOrigin";
			this.textBoxOrigin.Size = new System.Drawing.Size(158, 20);
			this.textBoxOrigin.TabIndex = 8;
			// 
			// labelOrigin
			// 
			this.labelOrigin.AutoSize = true;
			this.labelOrigin.Location = new System.Drawing.Point(6, 357);
			this.labelOrigin.Name = "labelOrigin";
			this.labelOrigin.Size = new System.Drawing.Size(66, 13);
			this.labelOrigin.TabIndex = 21;
			this.labelOrigin.Text = "Origin Plugin";
			// 
			// labelTags
			// 
			this.labelTags.AutoSize = true;
			this.labelTags.Location = new System.Drawing.Point(6, 272);
			this.labelTags.Name = "labelTags";
			this.labelTags.Size = new System.Drawing.Size(95, 13);
			this.labelTags.TabIndex = 20;
			this.labelTags.Text = "Tags (one per line)";
			// 
			// textBoxTags
			// 
			this.textBoxTags.Location = new System.Drawing.Point(9, 288);
			this.textBoxTags.Multiline = true;
			this.textBoxTags.Name = "textBoxTags";
			this.textBoxTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxTags.Size = new System.Drawing.Size(158, 60);
			this.textBoxTags.TabIndex = 7;
			// 
			// labelReturnType
			// 
			this.labelReturnType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelReturnType.AutoSize = true;
			this.labelReturnType.Location = new System.Drawing.Point(187, 384);
			this.labelReturnType.Name = "labelReturnType";
			this.labelReturnType.Size = new System.Drawing.Size(66, 13);
			this.labelReturnType.TabIndex = 18;
			this.labelReturnType.Text = "Return Type";
			this.labelReturnType.Visible = false;
			// 
			// labelParameters
			// 
			this.labelParameters.AutoSize = true;
			this.labelParameters.Location = new System.Drawing.Point(187, 16);
			this.labelParameters.Name = "labelParameters";
			this.labelParameters.Size = new System.Drawing.Size(60, 13);
			this.labelParameters.TabIndex = 16;
			this.labelParameters.Text = "Parameters";
			// 
			// groupBoxCallingConvention
			// 
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionEither);
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionBase);
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionRef);
			this.groupBoxCallingConvention.Location = new System.Drawing.Point(9, 145);
			this.groupBoxCallingConvention.Margin = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Name = "groupBoxCallingConvention";
			this.groupBoxCallingConvention.Padding = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Size = new System.Drawing.Size(158, 92);
			this.groupBoxCallingConvention.TabIndex = 5;
			this.groupBoxCallingConvention.TabStop = false;
			this.groupBoxCallingConvention.Text = "Calling Convention";
			// 
			// radioButtonCallingConventionEither
			// 
			this.radioButtonCallingConventionEither.AutoSize = true;
			this.radioButtonCallingConventionEither.Checked = true;
			this.radioButtonCallingConventionEither.Location = new System.Drawing.Point(10, 64);
			this.radioButtonCallingConventionEither.Name = "radioButtonCallingConventionEither";
			this.radioButtonCallingConventionEither.Size = new System.Drawing.Size(67, 17);
			this.radioButtonCallingConventionEither.TabIndex = 14;
			this.radioButtonCallingConventionEither.TabStop = true;
			this.radioButtonCallingConventionEither.Text = "By Either";
			this.radioButtonCallingConventionEither.UseVisualStyleBackColor = true;
			// 
			// radioButtonCallingConventionBase
			// 
			this.radioButtonCallingConventionBase.AutoSize = true;
			this.radioButtonCallingConventionBase.Location = new System.Drawing.Point(10, 40);
			this.radioButtonCallingConventionBase.Name = "radioButtonCallingConventionBase";
			this.radioButtonCallingConventionBase.Size = new System.Drawing.Size(64, 17);
			this.radioButtonCallingConventionBase.TabIndex = 13;
			this.radioButtonCallingConventionBase.Text = "By Base";
			this.radioButtonCallingConventionBase.UseVisualStyleBackColor = true;
			// 
			// radioButtonCallingConventionRef
			// 
			this.radioButtonCallingConventionRef.AutoSize = true;
			this.radioButtonCallingConventionRef.Location = new System.Drawing.Point(10, 16);
			this.radioButtonCallingConventionRef.Name = "radioButtonCallingConventionRef";
			this.radioButtonCallingConventionRef.Size = new System.Drawing.Size(90, 17);
			this.radioButtonCallingConventionRef.TabIndex = 12;
			this.radioButtonCallingConventionRef.Text = "By Reference";
			this.radioButtonCallingConventionRef.UseVisualStyleBackColor = true;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(6, 100);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(42, 13);
			this.labelVersion.TabIndex = 5;
			this.labelVersion.Text = "Version";
			// 
			// textBoxVersion
			// 
			this.textBoxVersion.Location = new System.Drawing.Point(9, 116);
			this.textBoxVersion.Name = "textBoxVersion";
			this.textBoxVersion.Size = new System.Drawing.Size(158, 20);
			this.textBoxVersion.TabIndex = 4;
			// 
			// textBoxAlias
			// 
			this.textBoxAlias.Location = new System.Drawing.Point(9, 74);
			this.textBoxAlias.Name = "textBoxAlias";
			this.textBoxAlias.Size = new System.Drawing.Size(158, 20);
			this.textBoxAlias.TabIndex = 3;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(9, 32);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(158, 20);
			this.textBoxName.TabIndex = 2;
			this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
			// 
			// labelAlias
			// 
			this.labelAlias.AutoSize = true;
			this.labelAlias.Location = new System.Drawing.Point(6, 58);
			this.labelAlias.Name = "labelAlias";
			this.labelAlias.Size = new System.Drawing.Size(29, 13);
			this.labelAlias.TabIndex = 1;
			this.labelAlias.Text = "Alias";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(6, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(35, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// checkBoxConditional
			// 
			this.checkBoxConditional.AutoSize = true;
			this.checkBoxConditional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxConditional.Location = new System.Drawing.Point(9, 246);
			this.checkBoxConditional.Name = "checkBoxConditional";
			this.checkBoxConditional.Size = new System.Drawing.Size(122, 17);
			this.checkBoxConditional.TabIndex = 6;
			this.checkBoxConditional.Text = "Conditional Function";
			this.checkBoxConditional.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(319, 120);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(436, 436);
			this.panel1.TabIndex = 503;
			// 
			// buttonListBoxDeleteItem
			// 
			this.buttonListBoxDeleteItem.AutoSize = true;
			this.buttonListBoxDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonListBoxDeleteItem.Enabled = false;
			this.buttonListBoxDeleteItem.Location = new System.Drawing.Point(12, 622);
			this.buttonListBoxDeleteItem.Name = "buttonListBoxDeleteItem";
			this.buttonListBoxDeleteItem.Size = new System.Drawing.Size(92, 23);
			this.buttonListBoxDeleteItem.TabIndex = 504;
			this.buttonListBoxDeleteItem.Text = "Delete Function";
			this.buttonListBoxDeleteItem.UseVisualStyleBackColor = true;
			this.buttonListBoxDeleteItem.Click += new System.EventHandler(this.buttonListBoxDeleteItem_Click);
			// 
			// buttonListBoxChangeCategory
			// 
			this.buttonListBoxChangeCategory.AutoSize = true;
			this.buttonListBoxChangeCategory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonListBoxChangeCategory.Enabled = false;
			this.buttonListBoxChangeCategory.Location = new System.Drawing.Point(110, 622);
			this.buttonListBoxChangeCategory.Name = "buttonListBoxChangeCategory";
			this.buttonListBoxChangeCategory.Size = new System.Drawing.Size(99, 23);
			this.buttonListBoxChangeCategory.TabIndex = 505;
			this.buttonListBoxChangeCategory.Text = "Change Category";
			this.buttonListBoxChangeCategory.UseVisualStyleBackColor = true;
			this.buttonListBoxChangeCategory.Click += new System.EventHandler(this.buttonListBoxChangeCategory_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1075, 677);
			this.Controls.Add(this.buttonListBoxChangeCategory);
			this.Controls.Add(this.buttonListBoxDeleteItem);
			this.Controls.Add(this.groupSelectionEditor);
			this.Controls.Add(this.listboxFunctionList);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.panel1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1091, 715);
			this.MinimumSize = new System.Drawing.Size(1091, 715);
			this.Name = "MainWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainMenu_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupSelectionEditor.ResumeLayout(false);
			this.groupSelectionEditor.PerformLayout();
			this.groupBoxReturnType.ResumeLayout(false);
			this.groupBoxReturnType.PerformLayout();
			this.flowLayoutPanelParameters.ResumeLayout(false);
			this.groupBoxParameterTemplate.ResumeLayout(false);
			this.groupBoxParameterTemplate.PerformLayout();
			this.groupBoxCallingConvention.ResumeLayout(false);
			this.groupBoxCallingConvention.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#region Form Declarations
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ListBox listboxFunctionList;
		private System.Windows.Forms.GroupBox groupSelectionEditor;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.TextBox textBoxVersion;
		private System.Windows.Forms.TextBox textBoxAlias;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelAlias;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.GroupBox groupBoxCallingConvention;
		private System.Windows.Forms.RadioButton radioButtonCallingConventionEither;
		private System.Windows.Forms.RadioButton radioButtonCallingConventionBase;
		private System.Windows.Forms.RadioButton radioButtonCallingConventionRef;
		private System.Windows.Forms.Label labelParameters;
		private System.Windows.Forms.TextBox textBoxOrigin;
		private System.Windows.Forms.Label labelOrigin;
		private System.Windows.Forms.Label labelTags;
		private System.Windows.Forms.TextBox textBoxTags;
		private System.Windows.Forms.Label labelReturnType;
		private System.Windows.Forms.TextBox textBoxCategory;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.Button buttonParametersNew;
		private System.Windows.Forms.Button buttonParameterCopy;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelParameters;
		private System.Windows.Forms.Button buttonSaveCurrentChanges;
		private System.Windows.Forms.Button buttonDiscardChanges;
		private System.Windows.Forms.GroupBox groupBoxReturnType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeURL;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeType;
		private System.Windows.Forms.CheckBox checkBoxReturnType;
		private System.Windows.Forms.Button buttonNewFunction;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonListBoxDeleteItem;
		private System.Windows.Forms.Button buttonListBoxChangeCategory;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.RichTextBox richTextBoxDescription;
		#endregion
		private System.Windows.Forms.ToolStripMenuItem resetEverythingToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxParameterTemplate;
		private System.Windows.Forms.Label labelParameterTemplateName;
		private System.Windows.Forms.ComboBox comboBoxParameterTemplateName;
		private System.Windows.Forms.Button buttonParameterTemplateRemove;
		private System.Windows.Forms.CheckBox checkBoxParameterTemplateOptional;
		private System.Windows.Forms.Label labelParameterTemplateURL;
		private System.Windows.Forms.Label labelParameterTemplateType;
		private System.Windows.Forms.ComboBox comboBoxParameterTemplateURL;
		private System.Windows.Forms.ComboBox comboBoxParameterTemplateType;
		private System.Windows.Forms.CheckBox checkBoxConditional;
	}
}

