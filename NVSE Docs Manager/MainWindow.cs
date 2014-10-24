﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Json;
using Newtonsoft;
using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{

		// array for parameters groups for each parameter
		List<Control> parametersList = new List<Control>();
		List<string> parameterURLList = new List<string>() { 
			"Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
		};
		List<string> parameterTypesList = new List<string>()
		{
			"scanCode:Integer"
		};


		// array of read in functions
		List<FunctionDef> LoadedFunctionsList = new List<FunctionDef>();

		// Stores a backup of the function currently being edited for restore and comparison purposes
		FunctionDef currentEdittingBackup = new FunctionDef();


		public MainWindow()
		{
			InitializeComponent();

			#region Register Mouse Event Handlers
			this.textBoxName.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxName.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxAlias.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxAlias.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxVersion.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxVersion.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.groupBoxCallingConvention.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.groupBoxCallingConvention.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			this.radioButtonCallingConventionRef.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.radioButtonCallingConventionRef.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			this.radioButtonCallingConventionBase.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.radioButtonCallingConventionBase.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			this.radioButtonCallingConventionEither.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.radioButtonCallingConventionEither.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.groupBoxConditional.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.groupBoxConditional.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			this.radioButtonConditionalTrue.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.radioButtonConditionalTrue.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			this.radioButtonConditionalFalse.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.radioButtonConditionalFalse.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxOrigin.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxOrigin.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxCategory.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxCategory.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.flowLayoutPanelParameters.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.flowLayoutPanelParameters.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
			#endregion
		}

		/// <summary>
		/// Outputs a string to the statusbar
		/// </summary>
		/// <param name="outString">A string of text to explain what the current action is.</param>
		private void outputToStatusbar(string outString)
		{
			toolStripStatusLabel1.Text = outString;
		}

		/// <summary>
		/// Turns a json encoded StreamReader file object into a list of FunctionDef objects.
		/// </summary>
		/// <param name="file">An input file object formatted in json.</param>
		private void parseLoadedFile(StreamReader file)
		{
			var funcList = JsonConvert.DeserializeObject<List<FunctionDef>>(file.ReadToEnd());
			populateFunctionListBox(funcList);
		}

		/// <summary>
		/// Takes a list of function objects and adds their names to the listbox form.
		/// </summary>
		/// <param name="functionList">A List&lt;T&gt; of FunctionDefs that will be added to the working list of functions.</param>
		private void populateFunctionListBox(List<FunctionDef> functionList)
		{
			foreach (FunctionDef f in functionList)
			{
				addToFunctionListBox(f);
			}
			foreach (FunctionDef f in functionList)
			{
				//if (treeView1.Nodes.ContainsKey(f.Category;))
			}
		}

		/// <summary>
		/// Checks if a function exists in the list and, if it's not, adds it to the list and updates the listbox
		/// </summary>
		/// <param name="functionToAdd">A function to add to the list of loaded functions</param>
		private void addToFunctionListBox(FunctionDef functionToAdd)
		{
			if (!LoadedFunctionsList.Exists(n => n.Name == functionToAdd.Name))
			{
				listboxFunctionList.Items.Add(functionToAdd.Name);
				LoadedFunctionsList.Add(functionToAdd);
			}
		}

		/// <summary>
		/// Takes a function and fills in all the window fields
		/// with their appropriate data
		/// </summary>
		public void populateFunctionForm(FunctionDef func)
		{
			flowLayoutPanelParameters.Controls.Clear();
			parametersList.Clear();
			textBoxName.Clear();
			textBoxAlias.Clear();
			textBoxVersion.Clear();
			textBoxOrigin.Clear();
			textBoxCategory.Clear();
			textBoxTags.Clear();
			richTextBoxDescription.Clear();
			radioButtonCallingConventionEither.Checked = true;
			radioButtonConditionalFalse.Checked = true;

			// save the settings to a global first, so we can revert if a bad change is made
			currentEdittingBackup = func;

			textBoxName.Text = func.Name;
			textBoxAlias.Text = func.Alias;
			textBoxVersion.Text = func.Version;
			textBoxOrigin.Text = func.FromPlugin;
			textBoxCategory.Text = func.Category;

			if (func.Tags != null)
				foreach (string s in func.Tags) { textBoxTags.Text += s + System.Environment.NewLine; }

			if (func.Convention == "B")
				radioButtonCallingConventionBase.Checked = true;
			else if (func.Convention == "E")
				radioButtonCallingConventionEither.Checked = true;
			else if (func.Convention == "R")
				radioButtonCallingConventionRef.Checked = true;

			// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
			if (func.Condition == "Yes")
				radioButtonConditionalTrue.Checked = true;
			else
				radioButtonConditionalFalse.Checked = true;

			populateParameterList(func.Parameters);

			if (func.ReturnType.Count > 0)
				if (!String.IsNullOrEmpty(func.ReturnType[0].type))
				{
					comboBoxReturnTypeURL.Text = func.ReturnType[0].type;
					comboBoxReturnTypeType.Text = func.ReturnType[0].type;
					checkBoxReturnType.Checked = true;
				}
				else
				{
					comboBoxReturnTypeURL.Text = "";
					comboBoxReturnTypeType.Text = "";
					checkBoxReturnType.Checked = false;
				}
			
			if (func.Description != null)
				foreach (string s in func.Description) { richTextBoxDescription.Text += s + System.Environment.NewLine + System.Environment.NewLine; }
		}

		/// <summary>
		/// Takes all the info in the window and creates a new function from it
		/// then adds it to the listbox and LoadedFunctionsList
		/// </summary>
		private void saveNewFunction()
		{
			FunctionDef func = windowToFunction(new FunctionDef());
			addToFunctionListBox(func);
		}

		/// <summary>
		/// Finds the current function by name and replaces its data with that in the window
		/// </summary>
		private void updateCurrentFunction()
		{
			windowToFunction(LoadedFunctionsList.Find(f => f.Name == textBoxName.Text));
		}

		/// <summary>
		/// Converts the window data into a function object
		/// </summary>
		/// <param name="functionToAdd">A function that will be returned filled with the data in the window.</param>
		private FunctionDef windowToFunction(FunctionDef function)
		{
			function.Name = textBoxName.Text;
			function.Alias = textBoxAlias.Text;
			function.Version = textBoxVersion.Text;
			function.FromPlugin = textBoxOrigin.Text;
			function.Category = textBoxCategory.Text;

			if (!String.IsNullOrEmpty(textBoxTags.Text))
			{
				foreach (string line in textBoxTags.Lines)
				{
					if (function.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
						function.Tags.Add(line);
				}
			}

			if (radioButtonCallingConventionBase.Checked == true)
				function.Convention = "B";
			else if (radioButtonCallingConventionEither.Checked == true)
				function.Convention = "E";
			else if (radioButtonCallingConventionRef.Checked == true)
				function.Convention = "R";

			// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
			if (radioButtonConditionalFalse.Checked == true)
				function.Condition = "No";
			else
				function.Condition = "Yes";

			function.Parameters.Clear();
			foreach (Control c in parametersList)
			{
				Parameter newParam = new Parameter();

				System.Windows.Forms.ComboBox cBox;
				System.Windows.Forms.CheckBox cBox2;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxURL"];
				newParam.url = cBox.Text;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxType"];
				newParam.type = cBox.Text;

				cBox2 = (System.Windows.Forms.CheckBox)c.Controls["checkBoxOptional"];
				newParam.optional = cBox2.Checked.ToString();

				function.Parameters.Add(newParam);
			}

			if (checkBoxReturnType.Checked)
			{
				function.ReturnType[0].type = comboBoxReturnTypeURL.Text;
				function.ReturnType[0].type = comboBoxReturnTypeType.Text;
			}

			if (!String.IsNullOrEmpty(richTextBoxDescription.Text))
			{
				foreach (string line in richTextBoxDescription.Lines)
				{
					if (!String.IsNullOrEmpty(line))
						function.Description.Add(line);
				}
			}

			return function;
		}



		/// <summary>
		/// Presents a Yes/No dialog option asking if the user has saved.
		/// Returns Yes or No
		/// </summary>
		private DialogResult confirmCloseForm()
		{
			DialogResult d = MessageBox.Show("Have you saved?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
			if (d == DialogResult.Yes)
			{
				return DialogResult.Yes;
			}
			return DialogResult.No;
		}

		/// <summary>
		/// Presents a dialog form with a text entry.
		/// </summary>
		/// <param name="title">Title of the form.</param>
		/// <param name="promptText">Text prompt to inform what the entered string is for.</param>
		/// <param name="value">String variable to hold the entered text.</param>
		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			form.StartPosition = FormStartPosition.CenterParent;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		private bool hasChanged()
		{
			FunctionDef toCheck = windowToFunction(new FunctionDef());
			if (toCheck.Equals(currentEdittingBackup))
				return false;
			return true;
		}
		
	}
}
