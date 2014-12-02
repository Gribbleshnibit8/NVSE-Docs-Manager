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
		/// <param name="disposing">
		///     true if managed resources should be disposed; otherwise, false.
		/// </param>
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemExportNotepadFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputReadableFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.convertWikiPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToUseThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.listboxFunctionList = new System.Windows.Forms.ListBox();
			this.groupSelectionEditor = new System.Windows.Forms.GroupBox();
			this.comboBoxReferenceType = new System.Windows.Forms.ComboBox();
			this.buttonShowExamples = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonNewFunction = new System.Windows.Forms.Button();
			this.groupBoxReturnType = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxReturnTypeValue = new System.Windows.Forms.ComboBox();
			this.labelReturnTypeName = new System.Windows.Forms.Label();
			this.checkBoxReturnType = new System.Windows.Forms.CheckBox();
			this.comboBoxReturnTypeName = new System.Windows.Forms.ComboBox();
			this.labelReturnTypeURL = new System.Windows.Forms.Label();
			this.labelReturnTypeType = new System.Windows.Forms.Label();
			this.comboBoxReturnTypeURL = new System.Windows.Forms.ComboBox();
			this.comboBoxReturnTypeType = new System.Windows.Forms.ComboBox();
			this.buttonDiscardChanges = new System.Windows.Forms.Button();
			this.buttonSaveCurrentChanges = new System.Windows.Forms.Button();
			this.flowLayoutPanelParameters = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonParametersNew = new System.Windows.Forms.Button();
			this.textBoxOrigin = new System.Windows.Forms.TextBox();
			this.labelOrigin = new System.Windows.Forms.Label();
			this.labelTags = new System.Windows.Forms.Label();
			this.textBoxTags = new System.Windows.Forms.TextBox();
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
			this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
			this.groupBoxParameterTemplate = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.labelParameterTemplateName = new System.Windows.Forms.Label();
			this.buttonParameterTemplateRemove = new System.Windows.Forms.Button();
			this.comboBoxParameterTemplateName = new System.Windows.Forms.ComboBox();
			this.comboBoxParameterTemplateType = new System.Windows.Forms.ComboBox();
			this.checkBoxParameterTemplateOptional = new System.Windows.Forms.CheckBox();
			this.labelParameterTemplateType = new System.Windows.Forms.Label();
			this.labelParameterTemplateURL = new System.Windows.Forms.Label();
			this.comboBoxParameterTemplateURL = new System.Windows.Forms.ComboBox();
			this.buttonListBoxDeleteItem = new System.Windows.Forms.Button();
			this.buttonListBoxAddTag = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.toolTipShortDelay = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1.SuspendLayout();
			this.groupSelectionEditor.SuspendLayout();
			this.groupBoxReturnType.SuspendLayout();
			this.groupBoxCallingConvention.SuspendLayout();
			this.groupBoxParameterTemplate.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "mainMenu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.resetToolStripMenuItem,
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
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExportNotepadFiles});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// toolStripMenuItemExportNotepadFiles
			// 
			this.toolStripMenuItemExportNotepadFiles.Name = "toolStripMenuItemExportNotepadFiles";
			this.toolStripMenuItemExportNotepadFiles.Size = new System.Drawing.Size(162, 22);
			this.toolStripMenuItemExportNotepadFiles.Text = "Notepad++ Files";
			this.toolStripMenuItemExportNotepadFiles.Click += new System.EventHandler(this.toolStripMenuItemExportNotepadFiles_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.L)));
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputReadableFileToolStripMenuItem,
            this.convertWikiPagesToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// outputReadableFileToolStripMenuItem
			// 
			this.outputReadableFileToolStripMenuItem.Name = "outputReadableFileToolStripMenuItem";
			this.outputReadableFileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.outputReadableFileToolStripMenuItem.Text = "Output Readable File";
			this.outputReadableFileToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
			// 
			// convertWikiPagesToolStripMenuItem
			// 
			this.convertWikiPagesToolStripMenuItem.Name = "convertWikiPagesToolStripMenuItem";
			this.convertWikiPagesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.convertWikiPagesToolStripMenuItem.Text = "Convert Wiki Pages";
			this.convertWikiPagesToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseThisToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// howToUseThisToolStripMenuItem
			// 
			this.howToUseThisToolStripMenuItem.Name = "howToUseThisToolStripMenuItem";
			this.howToUseThisToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.howToUseThisToolStripMenuItem.Text = "How to use this";
			this.howToUseThisToolStripMenuItem.Click += new System.EventHandler(this.howToUseThisToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// listboxFunctionList
			// 
			this.listboxFunctionList.AllowDrop = true;
			this.listboxFunctionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listboxFunctionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listboxFunctionList.FormattingEnabled = true;
			this.listboxFunctionList.ItemHeight = 16;
			this.listboxFunctionList.Location = new System.Drawing.Point(12, 33);
			this.listboxFunctionList.Name = "listboxFunctionList";
			this.listboxFunctionList.ScrollAlwaysVisible = true;
			this.listboxFunctionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listboxFunctionList.Size = new System.Drawing.Size(220, 596);
			this.listboxFunctionList.Sorted = true;
			this.listboxFunctionList.TabIndex = 1;
			this.listboxFunctionList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
			this.listboxFunctionList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listboxFuctionList_KeyUp);
			this.listboxFunctionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listboxFunctionList_MouseDoubleClick);
			this.listboxFunctionList.MouseEnter += new System.EventHandler(this.listboxFunctionList_MouseLeave);
			this.listboxFunctionList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listboxFunctionList_MouseUp);
			// 
			// groupSelectionEditor
			// 
			this.groupSelectionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupSelectionEditor.Controls.Add(this.comboBoxReferenceType);
			this.groupSelectionEditor.Controls.Add(this.buttonShowExamples);
			this.groupSelectionEditor.Controls.Add(this.label3);
			this.groupSelectionEditor.Controls.Add(this.buttonNewFunction);
			this.groupSelectionEditor.Controls.Add(this.groupBoxReturnType);
			this.groupSelectionEditor.Controls.Add(this.buttonDiscardChanges);
			this.groupSelectionEditor.Controls.Add(this.buttonSaveCurrentChanges);
			this.groupSelectionEditor.Controls.Add(this.flowLayoutPanelParameters);
			this.groupSelectionEditor.Controls.Add(this.buttonParametersNew);
			this.groupSelectionEditor.Controls.Add(this.textBoxOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelTags);
			this.groupSelectionEditor.Controls.Add(this.textBoxTags);
			this.groupSelectionEditor.Controls.Add(this.labelParameters);
			this.groupSelectionEditor.Controls.Add(this.groupBoxCallingConvention);
			this.groupSelectionEditor.Controls.Add(this.labelVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxAlias);
			this.groupSelectionEditor.Controls.Add(this.textBoxName);
			this.groupSelectionEditor.Controls.Add(this.labelAlias);
			this.groupSelectionEditor.Controls.Add(this.labelName);
			this.groupSelectionEditor.Controls.Add(this.checkBoxConditional);
			this.groupSelectionEditor.Controls.Add(this.richTextBoxDescription);
			this.groupSelectionEditor.Location = new System.Drawing.Point(238, 27);
			this.groupSelectionEditor.Name = "groupSelectionEditor";
			this.groupSelectionEditor.Size = new System.Drawing.Size(834, 630);
			this.groupSelectionEditor.TabIndex = 3;
			this.groupSelectionEditor.TabStop = false;
			// 
			// comboBoxReferenceType
			// 
			this.comboBoxReferenceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxReferenceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxReferenceType.FormattingEnabled = true;
			this.comboBoxReferenceType.Location = new System.Drawing.Point(9, 186);
			this.comboBoxReferenceType.Name = "comboBoxReferenceType";
			this.comboBoxReferenceType.Size = new System.Drawing.Size(158, 21);
			this.comboBoxReferenceType.TabIndex = 40;
			this.toolTipShortDelay.SetToolTip(this.comboBoxReferenceType, "The type returned by the function\r\nReplaces \"reference\" in the function definitio" +
        "n");
			// 
			// buttonShowExamples
			// 
			this.buttonShowExamples.Location = new System.Drawing.Point(198, 534);
			this.buttonShowExamples.Name = "buttonShowExamples";
			this.buttonShowExamples.Size = new System.Drawing.Size(150, 90);
			this.buttonShowExamples.TabIndex = 13;
			this.buttonShowExamples.Text = "Edit Examples";
			this.toolTipShortDelay.SetToolTip(this.buttonShowExamples, "Add examples to this function");
			this.buttonShowExamples.UseVisualStyleBackColor = true;
			this.buttonShowExamples.Click += new System.EventHandler(this.buttonShowExamples_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 172);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 39;
			this.label3.Text = "Reference Type";
			// 
			// buttonNewFunction
			// 
			this.buttonNewFunction.Location = new System.Drawing.Point(105, 534);
			this.buttonNewFunction.Name = "buttonNewFunction";
			this.buttonNewFunction.Size = new System.Drawing.Size(60, 43);
			this.buttonNewFunction.TabIndex = 502;
			this.buttonNewFunction.Text = "New Function";
			this.toolTipShortDelay.SetToolTip(this.buttonNewFunction, "Create a new function, clearing the form");
			this.buttonNewFunction.UseVisualStyleBackColor = true;
			this.buttonNewFunction.Click += new System.EventHandler(this.buttonNewFunction_Click);
			// 
			// groupBoxReturnType
			// 
			this.groupBoxReturnType.Controls.Add(this.label2);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeValue);
			this.groupBoxReturnType.Controls.Add(this.labelReturnTypeName);
			this.groupBoxReturnType.Controls.Add(this.checkBoxReturnType);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeName);
			this.groupBoxReturnType.Controls.Add(this.labelReturnTypeURL);
			this.groupBoxReturnType.Controls.Add(this.labelReturnTypeType);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeURL);
			this.groupBoxReturnType.Controls.Add(this.comboBoxReturnTypeType);
			this.groupBoxReturnType.Location = new System.Drawing.Point(9, 214);
			this.groupBoxReturnType.Name = "groupBoxReturnType";
			this.groupBoxReturnType.Size = new System.Drawing.Size(340, 126);
			this.groupBoxReturnType.TabIndex = 10;
			this.groupBoxReturnType.TabStop = false;
			this.groupBoxReturnType.Text = "Return Type";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(179, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 37;
			this.label2.Text = "Value";
			// 
			// comboBoxReturnTypeValue
			// 
			this.comboBoxReturnTypeValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxReturnTypeValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxReturnTypeValue.Enabled = false;
			this.comboBoxReturnTypeValue.FormattingEnabled = true;
			this.comboBoxReturnTypeValue.Location = new System.Drawing.Point(182, 55);
			this.comboBoxReturnTypeValue.Name = "comboBoxReturnTypeValue";
			this.comboBoxReturnTypeValue.Size = new System.Drawing.Size(140, 21);
			this.comboBoxReturnTypeValue.TabIndex = 38;
			this.toolTipShortDelay.SetToolTip(this.comboBoxReturnTypeValue, "The return value of the function");
			// 
			// labelReturnTypeName
			// 
			this.labelReturnTypeName.AutoSize = true;
			this.labelReturnTypeName.Enabled = false;
			this.labelReturnTypeName.Location = new System.Drawing.Point(179, 79);
			this.labelReturnTypeName.Name = "labelReturnTypeName";
			this.labelReturnTypeName.Size = new System.Drawing.Size(35, 13);
			this.labelReturnTypeName.TabIndex = 35;
			this.labelReturnTypeName.Text = "Name";
			// 
			// checkBoxReturnType
			// 
			this.checkBoxReturnType.AutoSize = true;
			this.checkBoxReturnType.Location = new System.Drawing.Point(6, 19);
			this.checkBoxReturnType.Name = "checkBoxReturnType";
			this.checkBoxReturnType.Size = new System.Drawing.Size(110, 17);
			this.checkBoxReturnType.TabIndex = 11;
			this.checkBoxReturnType.Text = "Has Return Value";
			this.toolTipShortDelay.SetToolTip(this.checkBoxReturnType, "Does the function have a return value");
			this.checkBoxReturnType.UseVisualStyleBackColor = true;
			this.checkBoxReturnType.CheckedChanged += new System.EventHandler(this.checkBoxReturnType_CheckedChanged);
			// 
			// comboBoxReturnTypeName
			// 
			this.comboBoxReturnTypeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxReturnTypeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxReturnTypeName.Enabled = false;
			this.comboBoxReturnTypeName.FormattingEnabled = true;
			this.comboBoxReturnTypeName.Location = new System.Drawing.Point(182, 95);
			this.comboBoxReturnTypeName.Name = "comboBoxReturnTypeName";
			this.comboBoxReturnTypeName.Size = new System.Drawing.Size(140, 21);
			this.comboBoxReturnTypeName.TabIndex = 36;
			this.toolTipShortDelay.SetToolTip(this.comboBoxReturnTypeName, "The name of the value");
			// 
			// labelReturnTypeURL
			// 
			this.labelReturnTypeURL.AutoSize = true;
			this.labelReturnTypeURL.Enabled = false;
			this.labelReturnTypeURL.Location = new System.Drawing.Point(6, 39);
			this.labelReturnTypeURL.Name = "labelReturnTypeURL";
			this.labelReturnTypeURL.Size = new System.Drawing.Size(29, 13);
			this.labelReturnTypeURL.TabIndex = 31;
			this.labelReturnTypeURL.Text = "URL";
			// 
			// labelReturnTypeType
			// 
			this.labelReturnTypeType.AutoSize = true;
			this.labelReturnTypeType.Enabled = false;
			this.labelReturnTypeType.Location = new System.Drawing.Point(6, 79);
			this.labelReturnTypeType.Name = "labelReturnTypeType";
			this.labelReturnTypeType.Size = new System.Drawing.Size(31, 13);
			this.labelReturnTypeType.TabIndex = 33;
			this.labelReturnTypeType.Text = "Type";
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
			this.comboBoxReturnTypeURL.Location = new System.Drawing.Point(6, 55);
			this.comboBoxReturnTypeURL.Name = "comboBoxReturnTypeURL";
			this.comboBoxReturnTypeURL.Size = new System.Drawing.Size(140, 21);
			this.comboBoxReturnTypeURL.Sorted = true;
			this.comboBoxReturnTypeURL.TabIndex = 32;
			this.toolTipShortDelay.SetToolTip(this.comboBoxReturnTypeURL, "URL to more information about\r\nspecific types of return values");
			// 
			// comboBoxReturnTypeType
			// 
			this.comboBoxReturnTypeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxReturnTypeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxReturnTypeType.Enabled = false;
			this.comboBoxReturnTypeType.FormattingEnabled = true;
			this.comboBoxReturnTypeType.Location = new System.Drawing.Point(6, 95);
			this.comboBoxReturnTypeType.Name = "comboBoxReturnTypeType";
			this.comboBoxReturnTypeType.Size = new System.Drawing.Size(140, 21);
			this.comboBoxReturnTypeType.TabIndex = 34;
			this.toolTipShortDelay.SetToolTip(this.comboBoxReturnTypeType, "The value type returned by the function");
			// 
			// buttonDiscardChanges
			// 
			this.buttonDiscardChanges.Location = new System.Drawing.Point(105, 581);
			this.buttonDiscardChanges.Name = "buttonDiscardChanges";
			this.buttonDiscardChanges.Size = new System.Drawing.Size(60, 43);
			this.buttonDiscardChanges.TabIndex = 501;
			this.buttonDiscardChanges.Text = " Discard Changes";
			this.toolTipShortDelay.SetToolTip(this.buttonDiscardChanges, "Discard all changes\r\nClears if working on a new function\r\nResets to loaded state " +
        "if editing a function");
			this.buttonDiscardChanges.UseVisualStyleBackColor = true;
			this.buttonDiscardChanges.Click += new System.EventHandler(this.buttonDiscardChanges_Click);
			// 
			// buttonSaveCurrentChanges
			// 
			this.buttonSaveCurrentChanges.Enabled = false;
			this.buttonSaveCurrentChanges.Location = new System.Drawing.Point(9, 534);
			this.buttonSaveCurrentChanges.Name = "buttonSaveCurrentChanges";
			this.buttonSaveCurrentChanges.Size = new System.Drawing.Size(90, 90);
			this.buttonSaveCurrentChanges.TabIndex = 500;
			this.buttonSaveCurrentChanges.Text = "Save\r\nChanges";
			this.buttonSaveCurrentChanges.UseVisualStyleBackColor = true;
			this.buttonSaveCurrentChanges.Click += new System.EventHandler(this.buttonSaveCurrentChanges_Click);
			// 
			// flowLayoutPanelParameters
			// 
			this.flowLayoutPanelParameters.AllowDrop = true;
			this.flowLayoutPanelParameters.AutoScroll = true;
			this.flowLayoutPanelParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flowLayoutPanelParameters.Location = new System.Drawing.Point(355, 35);
			this.flowLayoutPanelParameters.Name = "flowLayoutPanelParameters";
			this.flowLayoutPanelParameters.Size = new System.Drawing.Size(473, 589);
			this.flowLayoutPanelParameters.TabIndex = 11;
			this.flowLayoutPanelParameters.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelParameters_ControlAdded);
			this.flowLayoutPanelParameters.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelParameters_ControlRemoved);
			this.flowLayoutPanelParameters.MouseEnter += new System.EventHandler(this.flowLayoutPanelParameter_MouseEnter);
			// 
			// buttonParametersNew
			// 
			this.buttonParametersNew.AutoSize = true;
			this.buttonParametersNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonParametersNew.Location = new System.Drawing.Point(417, 11);
			this.buttonParametersNew.Name = "buttonParametersNew";
			this.buttonParametersNew.Size = new System.Drawing.Size(87, 23);
			this.buttonParametersNew.TabIndex = 11;
			this.buttonParametersNew.Text = "Add Parameter";
			this.toolTipShortDelay.SetToolTip(this.buttonParametersNew, "Add a new parameter at the end of the list");
			this.buttonParametersNew.UseVisualStyleBackColor = true;
			this.buttonParametersNew.Click += new System.EventHandler(this.buttonNewParameter_Click);
			// 
			// textBoxOrigin
			// 
			this.textBoxOrigin.Location = new System.Drawing.Point(9, 149);
			this.textBoxOrigin.Name = "textBoxOrigin";
			this.textBoxOrigin.Size = new System.Drawing.Size(158, 20);
			this.textBoxOrigin.TabIndex = 5;
			this.toolTipShortDelay.SetToolTip(this.textBoxOrigin, "Where the function comes from");
			// 
			// labelOrigin
			// 
			this.labelOrigin.AutoSize = true;
			this.labelOrigin.Location = new System.Drawing.Point(6, 133);
			this.labelOrigin.Name = "labelOrigin";
			this.labelOrigin.Size = new System.Drawing.Size(66, 13);
			this.labelOrigin.TabIndex = 21;
			this.labelOrigin.Text = "Origin Plugin";
			// 
			// labelTags
			// 
			this.labelTags.AutoSize = true;
			this.labelTags.Location = new System.Drawing.Point(187, 133);
			this.labelTags.Name = "labelTags";
			this.labelTags.Size = new System.Drawing.Size(95, 13);
			this.labelTags.TabIndex = 20;
			this.labelTags.Text = "Tags (one per line)";
			// 
			// textBoxTags
			// 
			this.textBoxTags.Location = new System.Drawing.Point(190, 149);
			this.textBoxTags.Multiline = true;
			this.textBoxTags.Name = "textBoxTags";
			this.textBoxTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxTags.Size = new System.Drawing.Size(159, 59);
			this.textBoxTags.TabIndex = 9;
			this.toolTipShortDelay.SetToolTip(this.textBoxTags, "Alternative methods of\r\nsearching for this function");
			// 
			// labelParameters
			// 
			this.labelParameters.AutoSize = true;
			this.labelParameters.Location = new System.Drawing.Point(351, 16);
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
			this.groupBoxCallingConvention.Location = new System.Drawing.Point(189, 16);
			this.groupBoxCallingConvention.Margin = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Name = "groupBoxCallingConvention";
			this.groupBoxCallingConvention.Padding = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Size = new System.Drawing.Size(159, 92);
			this.groupBoxCallingConvention.TabIndex = 7;
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
			this.toolTipShortDelay.SetToolTip(this.radioButtonCallingConventionEither, "Is the function called in\r\neither of the above ways");
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
			this.toolTipShortDelay.SetToolTip(this.radioButtonCallingConventionBase, "Is the function called by base form");
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
			this.toolTipShortDelay.SetToolTip(this.radioButtonCallingConventionRef, "Is the function called by reference");
			this.radioButtonCallingConventionRef.UseVisualStyleBackColor = true;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(6, 94);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(42, 13);
			this.labelVersion.TabIndex = 5;
			this.labelVersion.Text = "Version";
			// 
			// textBoxVersion
			// 
			this.textBoxVersion.Location = new System.Drawing.Point(9, 110);
			this.textBoxVersion.Name = "textBoxVersion";
			this.textBoxVersion.Size = new System.Drawing.Size(158, 20);
			this.textBoxVersion.TabIndex = 4;
			this.toolTipShortDelay.SetToolTip(this.textBoxVersion, "The version in which this function was added");
			// 
			// textBoxAlias
			// 
			this.textBoxAlias.Location = new System.Drawing.Point(9, 71);
			this.textBoxAlias.Name = "textBoxAlias";
			this.textBoxAlias.Size = new System.Drawing.Size(158, 20);
			this.textBoxAlias.TabIndex = 3;
			this.toolTipShortDelay.SetToolTip(this.textBoxAlias, "An alternate name for the function");
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(9, 32);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(158, 20);
			this.textBoxName.TabIndex = 2;
			this.toolTipShortDelay.SetToolTip(this.textBoxName, "The name of the function");
			this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
			// 
			// labelAlias
			// 
			this.labelAlias.AutoSize = true;
			this.labelAlias.Location = new System.Drawing.Point(6, 55);
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
			this.checkBoxConditional.Location = new System.Drawing.Point(190, 112);
			this.checkBoxConditional.Name = "checkBoxConditional";
			this.checkBoxConditional.Size = new System.Drawing.Size(122, 17);
			this.checkBoxConditional.TabIndex = 8;
			this.checkBoxConditional.Text = "Conditional Function";
			this.toolTipShortDelay.SetToolTip(this.checkBoxConditional, "Does this function appear\r\nin the conditional dialog");
			this.checkBoxConditional.UseVisualStyleBackColor = true;
			// 
			// richTextBoxDescription
			// 
			this.richTextBoxDescription.AcceptsTab = true;
			this.richTextBoxDescription.EnableAutoDragDrop = true;
			this.richTextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxDescription.Location = new System.Drawing.Point(9, 346);
			this.richTextBoxDescription.Name = "richTextBoxDescription";
			this.richTextBoxDescription.Size = new System.Drawing.Size(340, 182);
			this.richTextBoxDescription.TabIndex = 12;
			this.richTextBoxDescription.Text = "";
			this.toolTipShortDelay.SetToolTip(this.richTextBoxDescription, "Description about the function, extra notes, and other information");
			this.richTextBoxDescription.ZoomFactor = 1.201F;
			// 
			// groupBoxParameterTemplate
			// 
			this.groupBoxParameterTemplate.Controls.Add(this.button1);
			this.groupBoxParameterTemplate.Controls.Add(this.label1);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBox1);
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateName);
			this.groupBoxParameterTemplate.Controls.Add(this.buttonParameterTemplateRemove);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateName);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateType);
			this.groupBoxParameterTemplate.Controls.Add(this.checkBoxParameterTemplateOptional);
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateType);
			this.groupBoxParameterTemplate.Controls.Add(this.labelParameterTemplateURL);
			this.groupBoxParameterTemplate.Controls.Add(this.comboBoxParameterTemplateURL);
			this.groupBoxParameterTemplate.Location = new System.Drawing.Point(238, 635);
			this.groupBoxParameterTemplate.Name = "groupBoxParameterTemplate";
			this.groupBoxParameterTemplate.Size = new System.Drawing.Size(435, 70);
			this.groupBoxParameterTemplate.TabIndex = 31;
			this.groupBoxParameterTemplate.TabStop = false;
			this.groupBoxParameterTemplate.Text = "ParameterBox 1";
			this.groupBoxParameterTemplate.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(30, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 21);
			this.button1.TabIndex = 33;
			this.button1.Text = "C";
			this.button1.UseVisualStyleBackColor = true;
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
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(283, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(140, 21);
			this.comboBox1.TabIndex = 31;
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
			// 
			// comboBoxParameterTemplateName
			// 
			this.comboBoxParameterTemplateName.FormattingEnabled = true;
			this.comboBoxParameterTemplateName.Location = new System.Drawing.Point(284, 40);
			this.comboBoxParameterTemplateName.Name = "comboBoxParameterTemplateName";
			this.comboBoxParameterTemplateName.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateName.TabIndex = 30;
			// 
			// comboBoxParameterTemplateType
			// 
			this.comboBoxParameterTemplateType.FormattingEnabled = true;
			this.comboBoxParameterTemplateType.Location = new System.Drawing.Point(96, 40);
			this.comboBoxParameterTemplateType.Name = "comboBoxParameterTemplateType";
			this.comboBoxParameterTemplateType.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateType.TabIndex = 3;
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
			this.comboBoxParameterTemplateURL.Location = new System.Drawing.Point(97, 13);
			this.comboBoxParameterTemplateURL.Name = "comboBoxParameterTemplateURL";
			this.comboBoxParameterTemplateURL.Size = new System.Drawing.Size(140, 21);
			this.comboBoxParameterTemplateURL.Sorted = true;
			this.comboBoxParameterTemplateURL.TabIndex = 1;
			// 
			// buttonListBoxDeleteItem
			// 
			this.buttonListBoxDeleteItem.AutoSize = true;
			this.buttonListBoxDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonListBoxDeleteItem.Enabled = false;
			this.buttonListBoxDeleteItem.Location = new System.Drawing.Point(12, 634);
			this.buttonListBoxDeleteItem.Name = "buttonListBoxDeleteItem";
			this.buttonListBoxDeleteItem.Size = new System.Drawing.Size(92, 23);
			this.buttonListBoxDeleteItem.TabIndex = 504;
			this.buttonListBoxDeleteItem.Text = "Delete Function";
			this.buttonListBoxDeleteItem.UseVisualStyleBackColor = true;
			this.buttonListBoxDeleteItem.Click += new System.EventHandler(this.buttonListBoxDeleteItem_Click);
			// 
			// buttonListBoxAddTag
			// 
			this.buttonListBoxAddTag.AutoSize = true;
			this.buttonListBoxAddTag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonListBoxAddTag.Enabled = false;
			this.buttonListBoxAddTag.Location = new System.Drawing.Point(144, 634);
			this.buttonListBoxAddTag.Name = "buttonListBoxAddTag";
			this.buttonListBoxAddTag.Size = new System.Drawing.Size(89, 23);
			this.buttonListBoxAddTag.TabIndex = 505;
			this.buttonListBoxAddTag.Text = "Batch Add Tag";
			this.buttonListBoxAddTag.UseVisualStyleBackColor = true;
			this.buttonListBoxAddTag.Click += new System.EventHandler(this.buttonListBatchAddTag_Click);
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Location = new System.Drawing.Point(294, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 0);
			this.panel1.TabIndex = 506;
			this.panel1.Visible = false;
			// 
			// BottomToolStripPanel
			// 
			this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// TopToolStripPanel
			// 
			this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// RightToolStripPanel
			// 
			this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// LeftToolStripPanel
			// 
			this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// toolTipShortDelay
			// 
			this.toolTipShortDelay.AutoPopDelay = 5000;
			this.toolTipShortDelay.InitialDelay = 100;
			this.toolTipShortDelay.ReshowDelay = 100;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 682);
			this.Controls.Add(this.groupBoxParameterTemplate);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonListBoxAddTag);
			this.Controls.Add(this.buttonListBoxDeleteItem);
			this.Controls.Add(this.groupSelectionEditor);
			this.Controls.Add(this.listboxFunctionList);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1100, 720);
			this.MinimumSize = new System.Drawing.Size(1100, 720);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainMenu_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupSelectionEditor.ResumeLayout(false);
			this.groupSelectionEditor.PerformLayout();
			this.groupBoxReturnType.ResumeLayout(false);
			this.groupBoxReturnType.PerformLayout();
			this.groupBoxCallingConvention.ResumeLayout(false);
			this.groupBoxCallingConvention.PerformLayout();
			this.groupBoxParameterTemplate.ResumeLayout(false);
			this.groupBoxParameterTemplate.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ListBox listboxFunctionList;
		private System.Windows.Forms.GroupBox groupSelectionEditor;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.TextBox textBoxVersion;
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
		private System.Windows.Forms.Button buttonParametersNew;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelParameters;
		private System.Windows.Forms.Button buttonSaveCurrentChanges;
		private System.Windows.Forms.Button buttonDiscardChanges;
		private System.Windows.Forms.GroupBox groupBoxReturnType;
		private System.Windows.Forms.CheckBox checkBoxReturnType;
		private System.Windows.Forms.Button buttonNewFunction;
		private System.Windows.Forms.Button buttonListBoxDeleteItem;
		private System.Windows.Forms.Button buttonListBoxAddTag;
		private System.Windows.Forms.RichTextBox richTextBoxDescription;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
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
		private System.Windows.Forms.Label labelReturnTypeName;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeName;
		private System.Windows.Forms.Label labelReturnTypeURL;
		private System.Windows.Forms.Label labelReturnTypeType;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeURL;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeType;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonShowExamples;
		private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
		private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
		private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
		private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		private System.Windows.Forms.ToolStripMenuItem outputReadableFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem convertWikiPagesToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxReturnTypeValue;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxReferenceType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxAlias;
		private System.Windows.Forms.ToolTip toolTipShortDelay;
		private System.Windows.Forms.ToolStripMenuItem howToUseThisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportNotepadFiles;
	}
}

