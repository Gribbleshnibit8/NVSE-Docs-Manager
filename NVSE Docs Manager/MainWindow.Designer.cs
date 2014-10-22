﻿namespace NVSE_Docs_Manager
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
			this.buttonSaveCurrentChanges = new System.Windows.Forms.Button();
			this.flowLayoutPanelParameters = new System.Windows.Forms.FlowLayoutPanel();
			this.parameter1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.labelParameter1URL = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.buttonParameterCopy = new System.Windows.Forms.Button();
			this.buttonParametersNew = new System.Windows.Forms.Button();
			this.textBoxCategory = new System.Windows.Forms.TextBox();
			this.labelCategory = new System.Windows.Forms.Label();
			this.labelExamples = new System.Windows.Forms.Label();
			this.panelExamples = new System.Windows.Forms.Panel();
			this.textBoxOrigin = new System.Windows.Forms.TextBox();
			this.labelOrigin = new System.Windows.Forms.Label();
			this.labelTags = new System.Windows.Forms.Label();
			this.textBoxTags = new System.Windows.Forms.TextBox();
			this.labelReturnType = new System.Windows.Forms.Label();
			this.labelParameters = new System.Windows.Forms.Label();
			this.panelReturnType = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBoxConditional = new System.Windows.Forms.GroupBox();
			this.radioButtonConditionalFalse = new System.Windows.Forms.RadioButton();
			this.radioButtonConditionalTrue = new System.Windows.Forms.RadioButton();
			this.groupBoxCallingConvention = new System.Windows.Forms.GroupBox();
			this.radioButtonCallingConventionEither = new System.Windows.Forms.RadioButton();
			this.radioButtonCallingConventionBase = new System.Windows.Forms.RadioButton();
			this.radioButtonCallingConventionRef = new System.Windows.Forms.RadioButton();
			this.labelConditional = new System.Windows.Forms.Label();
			this.labelCallingConvention = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.textBoxVersion = new System.Windows.Forms.TextBox();
			this.textBoxAlias = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelAlias = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupSelectionEditor.SuspendLayout();
			this.flowLayoutPanelParameters.SuspendLayout();
			this.parameter1.SuspendLayout();
			this.panelReturnType.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBoxConditional.SuspendLayout();
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
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
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
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
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
			this.listboxFunctionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listboxFunctionList.FormattingEnabled = true;
			this.listboxFunctionList.Location = new System.Drawing.Point(12, 36);
			this.listboxFunctionList.Name = "listboxFunctionList";
			this.listboxFunctionList.ScrollAlwaysVisible = true;
			this.listboxFunctionList.Size = new System.Drawing.Size(300, 602);
			this.listboxFunctionList.TabIndex = 2;
			this.listboxFunctionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listboxFunctionList_MouseDoubleClick);
			// 
			// groupSelectionEditor
			// 
			this.groupSelectionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupSelectionEditor.Controls.Add(this.button1);
			this.groupSelectionEditor.Controls.Add(this.buttonSaveCurrentChanges);
			this.groupSelectionEditor.Controls.Add(this.flowLayoutPanelParameters);
			this.groupSelectionEditor.Controls.Add(this.buttonParameterCopy);
			this.groupSelectionEditor.Controls.Add(this.buttonParametersNew);
			this.groupSelectionEditor.Controls.Add(this.textBoxCategory);
			this.groupSelectionEditor.Controls.Add(this.labelCategory);
			this.groupSelectionEditor.Controls.Add(this.labelExamples);
			this.groupSelectionEditor.Controls.Add(this.panelExamples);
			this.groupSelectionEditor.Controls.Add(this.textBoxOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelOrigin);
			this.groupSelectionEditor.Controls.Add(this.labelTags);
			this.groupSelectionEditor.Controls.Add(this.textBoxTags);
			this.groupSelectionEditor.Controls.Add(this.labelReturnType);
			this.groupSelectionEditor.Controls.Add(this.labelParameters);
			this.groupSelectionEditor.Controls.Add(this.panelReturnType);
			this.groupSelectionEditor.Controls.Add(this.groupBoxConditional);
			this.groupSelectionEditor.Controls.Add(this.groupBoxCallingConvention);
			this.groupSelectionEditor.Controls.Add(this.labelConditional);
			this.groupSelectionEditor.Controls.Add(this.labelCallingConvention);
			this.groupSelectionEditor.Controls.Add(this.labelVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxVersion);
			this.groupSelectionEditor.Controls.Add(this.textBoxAlias);
			this.groupSelectionEditor.Controls.Add(this.textBoxName);
			this.groupSelectionEditor.Controls.Add(this.labelAlias);
			this.groupSelectionEditor.Controls.Add(this.labelName);
			this.groupSelectionEditor.Location = new System.Drawing.Point(318, 30);
			this.groupSelectionEditor.Name = "groupSelectionEditor";
			this.groupSelectionEditor.Size = new System.Drawing.Size(746, 612);
			this.groupSelectionEditor.TabIndex = 3;
			this.groupSelectionEditor.TabStop = false;
			// 
			// buttonSaveCurrentChanges
			// 
			this.buttonSaveCurrentChanges.Location = new System.Drawing.Point(9, 501);
			this.buttonSaveCurrentChanges.Name = "buttonSaveCurrentChanges";
			this.buttonSaveCurrentChanges.Size = new System.Drawing.Size(92, 105);
			this.buttonSaveCurrentChanges.TabIndex = 28;
			this.buttonSaveCurrentChanges.Text = "Save\r\nChanges";
			this.buttonSaveCurrentChanges.UseVisualStyleBackColor = true;
			this.buttonSaveCurrentChanges.Click += new System.EventHandler(this.buttonSaveCurrentChanges_Click);
			// 
			// flowLayoutPanelParameters
			// 
			this.flowLayoutPanelParameters.AutoScroll = true;
			this.flowLayoutPanelParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanelParameters.Controls.Add(this.parameter1);
			this.flowLayoutPanelParameters.Location = new System.Drawing.Point(190, 48);
			this.flowLayoutPanelParameters.Name = "flowLayoutPanelParameters";
			this.flowLayoutPanelParameters.Size = new System.Drawing.Size(550, 328);
			this.flowLayoutPanelParameters.TabIndex = 1;
			// 
			// parameter1
			// 
			this.parameter1.AutoSize = true;
			this.parameter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.parameter1.Controls.Add(this.button2);
			this.parameter1.Controls.Add(this.comboBox3);
			this.parameter1.Controls.Add(this.labelParameter1URL);
			this.parameter1.Controls.Add(this.label2);
			this.parameter1.Controls.Add(this.label1);
			this.parameter1.Controls.Add(this.comboBox1);
			this.parameter1.Controls.Add(this.comboBox2);
			this.parameter1.Location = new System.Drawing.Point(3, 3);
			this.parameter1.Name = "parameter1";
			this.parameter1.Size = new System.Drawing.Size(519, 61);
			this.parameter1.TabIndex = 0;
			this.parameter1.TabStop = false;
			this.parameter1.Text = "Parameter 1";
			this.parameter1.Visible = false;
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Location = new System.Drawing.Point(6, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(24, 23);
			this.button2.TabIndex = 28;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "True",
            "False"});
			this.comboBox3.Location = new System.Drawing.Point(428, 20);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(85, 21);
			this.comboBox3.TabIndex = 5;
			// 
			// labelParameter1URL
			// 
			this.labelParameter1URL.AutoSize = true;
			this.labelParameter1URL.Location = new System.Drawing.Point(36, 24);
			this.labelParameter1URL.Name = "labelParameter1URL";
			this.labelParameter1URL.Size = new System.Drawing.Size(29, 13);
			this.labelParameter1URL.TabIndex = 0;
			this.labelParameter1URL.Text = "URL";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(376, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Optional";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(198, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Type";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
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
			this.comboBox1.Location = new System.Drawing.Point(71, 20);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 1;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(233, 20);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(137, 21);
			this.comboBox2.TabIndex = 3;
			// 
			// buttonParameterCopy
			// 
			this.buttonParameterCopy.AutoSize = true;
			this.buttonParameterCopy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonParameterCopy.Location = new System.Drawing.Point(349, 24);
			this.buttonParameterCopy.Name = "buttonParameterCopy";
			this.buttonParameterCopy.Size = new System.Drawing.Size(64, 23);
			this.buttonParameterCopy.TabIndex = 27;
			this.buttonParameterCopy.Text = "Copy Last";
			this.buttonParameterCopy.UseVisualStyleBackColor = true;
			this.buttonParameterCopy.Click += new System.EventHandler(this.buttonParameterCopy_Click);
			// 
			// buttonParametersNew
			// 
			this.buttonParametersNew.AutoSize = true;
			this.buttonParametersNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonParametersNew.Location = new System.Drawing.Point(253, 24);
			this.buttonParametersNew.Name = "buttonParametersNew";
			this.buttonParametersNew.Size = new System.Drawing.Size(90, 23);
			this.buttonParametersNew.TabIndex = 1;
			this.buttonParametersNew.Text = "New Parameter";
			this.buttonParametersNew.UseVisualStyleBackColor = true;
			this.buttonParametersNew.Click += new System.EventHandler(this.buttonParametersNew_Click);
			// 
			// textBoxCategory
			// 
			this.textBoxCategory.Location = new System.Drawing.Point(9, 475);
			this.textBoxCategory.Name = "textBoxCategory";
			this.textBoxCategory.Size = new System.Drawing.Size(158, 20);
			this.textBoxCategory.TabIndex = 26;
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(6, 459);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(49, 13);
			this.labelCategory.TabIndex = 25;
			this.labelCategory.Text = "Category";
			// 
			// labelExamples
			// 
			this.labelExamples.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelExamples.AutoSize = true;
			this.labelExamples.Location = new System.Drawing.Point(139, 595);
			this.labelExamples.Name = "labelExamples";
			this.labelExamples.Size = new System.Drawing.Size(52, 13);
			this.labelExamples.TabIndex = 24;
			this.labelExamples.Text = "Examples";
			// 
			// panelExamples
			// 
			this.panelExamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelExamples.AutoScroll = true;
			this.panelExamples.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelExamples.Location = new System.Drawing.Point(197, 547);
			this.panelExamples.Name = "panelExamples";
			this.panelExamples.Size = new System.Drawing.Size(518, 65);
			this.panelExamples.TabIndex = 23;
			// 
			// textBoxOrigin
			// 
			this.textBoxOrigin.Location = new System.Drawing.Point(9, 430);
			this.textBoxOrigin.Name = "textBoxOrigin";
			this.textBoxOrigin.Size = new System.Drawing.Size(158, 20);
			this.textBoxOrigin.TabIndex = 22;
			// 
			// labelOrigin
			// 
			this.labelOrigin.AutoSize = true;
			this.labelOrigin.Location = new System.Drawing.Point(6, 414);
			this.labelOrigin.Name = "labelOrigin";
			this.labelOrigin.Size = new System.Drawing.Size(66, 13);
			this.labelOrigin.TabIndex = 21;
			this.labelOrigin.Text = "Origin Plugin";
			// 
			// labelTags
			// 
			this.labelTags.AutoSize = true;
			this.labelTags.Location = new System.Drawing.Point(9, 332);
			this.labelTags.Name = "labelTags";
			this.labelTags.Size = new System.Drawing.Size(95, 13);
			this.labelTags.TabIndex = 20;
			this.labelTags.Text = "Tags (one per line)";
			// 
			// textBoxTags
			// 
			this.textBoxTags.Location = new System.Drawing.Point(9, 348);
			this.textBoxTags.Multiline = true;
			this.textBoxTags.Name = "textBoxTags";
			this.textBoxTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxTags.Size = new System.Drawing.Size(158, 60);
			this.textBoxTags.TabIndex = 19;
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
			// 
			// labelParameters
			// 
			this.labelParameters.AutoSize = true;
			this.labelParameters.Location = new System.Drawing.Point(187, 29);
			this.labelParameters.Name = "labelParameters";
			this.labelParameters.Size = new System.Drawing.Size(60, 13);
			this.labelParameters.TabIndex = 16;
			this.labelParameters.Text = "Parameters";
			// 
			// panelReturnType
			// 
			this.panelReturnType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelReturnType.AutoScroll = true;
			this.panelReturnType.AutoSize = true;
			this.panelReturnType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelReturnType.Controls.Add(this.groupBox1);
			this.panelReturnType.Location = new System.Drawing.Point(190, 400);
			this.panelReturnType.Name = "panelReturnType";
			this.panelReturnType.Size = new System.Drawing.Size(550, 72);
			this.panelReturnType.TabIndex = 17;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.comboBox6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(489, 42);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Parameter 1";
			this.groupBox1.Visible = false;
			// 
			// comboBox5
			// 
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Location = new System.Drawing.Point(203, 13);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(137, 21);
			this.comboBox5.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Type";
			// 
			// comboBox6
			// 
			this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox6.FormattingEnabled = true;
			this.comboBox6.Items.AddRange(new object[] {
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
			this.comboBox6.Location = new System.Drawing.Point(41, 13);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(121, 21);
			this.comboBox6.Sorted = true;
			this.comboBox6.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "URL";
			// 
			// groupBoxConditional
			// 
			this.groupBoxConditional.AutoSize = true;
			this.groupBoxConditional.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxConditional.Controls.Add(this.radioButtonConditionalFalse);
			this.groupBoxConditional.Controls.Add(this.radioButtonConditionalTrue);
			this.groupBoxConditional.Location = new System.Drawing.Point(9, 277);
			this.groupBoxConditional.Margin = new System.Windows.Forms.Padding(0);
			this.groupBoxConditional.Name = "groupBoxConditional";
			this.groupBoxConditional.Padding = new System.Windows.Forms.Padding(0);
			this.groupBoxConditional.Size = new System.Drawing.Size(116, 49);
			this.groupBoxConditional.TabIndex = 15;
			this.groupBoxConditional.TabStop = false;
			// 
			// radioButtonConditionalFalse
			// 
			this.radioButtonConditionalFalse.AutoSize = true;
			this.radioButtonConditionalFalse.Checked = true;
			this.radioButtonConditionalFalse.Location = new System.Drawing.Point(63, 16);
			this.radioButtonConditionalFalse.Name = "radioButtonConditionalFalse";
			this.radioButtonConditionalFalse.Size = new System.Drawing.Size(50, 17);
			this.radioButtonConditionalFalse.TabIndex = 13;
			this.radioButtonConditionalFalse.TabStop = true;
			this.radioButtonConditionalFalse.Text = "False";
			this.radioButtonConditionalFalse.UseVisualStyleBackColor = true;
			// 
			// radioButtonConditionalTrue
			// 
			this.radioButtonConditionalTrue.AutoSize = true;
			this.radioButtonConditionalTrue.Location = new System.Drawing.Point(10, 16);
			this.radioButtonConditionalTrue.Name = "radioButtonConditionalTrue";
			this.radioButtonConditionalTrue.Size = new System.Drawing.Size(47, 17);
			this.radioButtonConditionalTrue.TabIndex = 12;
			this.radioButtonConditionalTrue.Text = "True";
			this.radioButtonConditionalTrue.UseVisualStyleBackColor = true;
			// 
			// groupBoxCallingConvention
			// 
			this.groupBoxCallingConvention.AutoSize = true;
			this.groupBoxCallingConvention.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionEither);
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionBase);
			this.groupBoxCallingConvention.Controls.Add(this.radioButtonCallingConventionRef);
			this.groupBoxCallingConvention.Location = new System.Drawing.Point(9, 155);
			this.groupBoxCallingConvention.Margin = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Name = "groupBoxCallingConvention";
			this.groupBoxCallingConvention.Padding = new System.Windows.Forms.Padding(0);
			this.groupBoxCallingConvention.Size = new System.Drawing.Size(103, 97);
			this.groupBoxCallingConvention.TabIndex = 11;
			this.groupBoxCallingConvention.TabStop = false;
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
			this.radioButtonCallingConventionBase.Location = new System.Drawing.Point(10, 39);
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
			// labelConditional
			// 
			this.labelConditional.AutoSize = true;
			this.labelConditional.Location = new System.Drawing.Point(6, 264);
			this.labelConditional.Name = "labelConditional";
			this.labelConditional.Size = new System.Drawing.Size(103, 13);
			this.labelConditional.TabIndex = 9;
			this.labelConditional.Text = "Conditional Function";
			// 
			// labelCallingConvention
			// 
			this.labelCallingConvention.AutoSize = true;
			this.labelCallingConvention.Location = new System.Drawing.Point(6, 142);
			this.labelCallingConvention.Name = "labelCallingConvention";
			this.labelCallingConvention.Size = new System.Drawing.Size(95, 13);
			this.labelCallingConvention.TabIndex = 6;
			this.labelCallingConvention.Text = "Calling Convention";
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(108, 502);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(59, 56);
			this.button1.TabIndex = 29;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1075, 677);
			this.Controls.Add(this.groupSelectionEditor);
			this.Controls.Add(this.listboxFunctionList);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1091, 715);
			this.MinimumSize = new System.Drawing.Size(1091, 715);
			this.Name = "MainWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupSelectionEditor.ResumeLayout(false);
			this.groupSelectionEditor.PerformLayout();
			this.flowLayoutPanelParameters.ResumeLayout(false);
			this.flowLayoutPanelParameters.PerformLayout();
			this.parameter1.ResumeLayout(false);
			this.parameter1.PerformLayout();
			this.panelReturnType.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBoxConditional.ResumeLayout(false);
			this.groupBoxConditional.PerformLayout();
			this.groupBoxCallingConvention.ResumeLayout(false);
			this.groupBoxCallingConvention.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

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
		private System.Windows.Forms.Label labelConditional;
		private System.Windows.Forms.Label labelCallingConvention;
		private System.Windows.Forms.RadioButton radioButtonConditionalFalse;
		private System.Windows.Forms.RadioButton radioButtonConditionalTrue;
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
		private System.Windows.Forms.Panel panelReturnType;
		private System.Windows.Forms.TextBox textBoxCategory;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.GroupBox groupBoxConditional;
		private System.Windows.Forms.Button buttonParametersNew;
		private System.Windows.Forms.Button buttonParameterCopy;
		private System.Windows.Forms.Label labelExamples;
		private System.Windows.Forms.Panel panelExamples;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox parameter1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label labelParameter1URL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelParameters;
		private System.Windows.Forms.Button buttonSaveCurrentChanges;
		private System.Windows.Forms.Button button1;
	}
}
