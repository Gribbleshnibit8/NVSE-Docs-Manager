using System;
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

		// input file
		StreamReader inFile;

		// array of read in functions
		List<FunctionDef> LoadedFunctionsList = new List<FunctionDef>();

		// Stores a backup of the function currently being edited for restore and comparison purposes
		FunctionDef currentEdittingBackup = new FunctionDef();


		public MainWindow()
		{
			InitializeComponent();

			#region mouseEventHandlers

			// register mouse event handlers
			this.textBoxName.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			//this.nameTextBox.MouseHover += new System.EventHandler(this.formMouseEventHandler_MouseHover);
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

			#endregion mouseEventHandlers


			TreeNode ParentNode1;
			TreeNode ParentNode2;

			ParentNode1 = treeView1.Nodes.Add("tv1");
			ParentNode1.Nodes.Add("tv1FirstChild");
			ParentNode1.Nodes.Add("tv1SecondChild");
			ParentNode1.Nodes.Add("tv1ThirdChild");
			ParentNode1.Nodes.Add("tv1FourthChild");
			ParentNode1 = treeView1.Nodes.Add("tv2");
			ParentNode1.Nodes.Add("tv2FirstChild");
			ParentNode1.Nodes.Add("tv2SecondChild");
			ParentNode1.Expand();

			ParentNode2 = treeView2.Nodes.Add("tv3");
			ParentNode2.Nodes.Add("tv3FirstChild");
			ParentNode2.Nodes.Add("tv3SecondChild");
			//ParentNode2.Expand();
			//this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
			//this.treeView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
			//this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
			//this.treeView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
			//this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
			//this.treeView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);	


			this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(TreeManager.treeView1_ItemDrag);
			this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(TreeManager.treeView1_DragEnter);
			this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(TreeManager.treeView1_DragDrop);
		}

		



		


		/// <summary>
		/// Outputs a string to the statusbar
		/// </summary>
		/// <param name="outString">A string of text to explain what the current action is.</param>
		private void outputToStatusbar(string outString)
		{
			toolStripStatusLabel1.Text = outString;
		}

	// Tool strip handlers
		private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				inFile = new StreamReader(openFileDialog1.FileName);
				//MessageBox.Show(inFile.ReadToEnd());
				parseLoadedFile(inFile);
				inFile.Close();
			}
		}

		private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				saveFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
				StreamReader sr = new
				   StreamReader(saveFileDialog1.FileName);
				MessageBox.Show(sr.ReadToEnd());
				sr.Close();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				System.Windows.Forms.Application.Exit();
			} 
		}
	// End tool strip handlers

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

		// Takes a function and fills in all the fields with the associated data
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
		}

		// Takes all the info in the window and creates a new function from it
		// then adds it to the listbox and LoadedFunctionsList
		private void saveNewFunction()
		{
			FunctionDef func = windowToFunction(new FunctionDef());
			addToFunctionListBox(func);
		}

		// Overwrites the function with the same name as that in the window with
		// all of the data in the window
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
					;
					if (function.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
						function.Tags.Add(line);
				}
				//function.Tags.AddRange(textBoxTags.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
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

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxURL"];
				newParam.url = cBox.Text;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxType"];
				newParam.type = cBox.Text;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxOptional"];
				newParam.optional = cBox.Text;

				function.Parameters.Add(newParam);
			}

			if (checkBoxReturnType.Checked)
			{
				function.ReturnType[0].type = comboBoxReturnTypeURL.Text;
				function.ReturnType[0].type = comboBoxReturnTypeType.Text;
			}
			return function;
		}

		private bool hasChanged()
		{
			FunctionDef toCheck = windowToFunction(new FunctionDef());
			if (toCheck.Equals(currentEdittingBackup))
				return false;
			return true;
		}

		private void buttonNewFunction_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Are you sure you want to clear the form?", "New Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d == DialogResult.Yes)
				populateFunctionForm(new FunctionDef());
		}


	}
}
