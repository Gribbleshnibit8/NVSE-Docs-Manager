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

using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{

		#region Variables
		/// <summary>
		/// A list of Parameter Control objects displayed in the current form
		/// </summary>
		List<Control> parametersList = new List<Control>();

		List<string> parameterURLList = new List<string>() { 
			"Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Format_Specifiers", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
		};

		/// <summary>
		/// A list of all the names from the left-hand side of the ParameterDef type
		/// </summary>
		List<string> parameterTypesList = new List<string>();

		/// <summary>
		/// A list of all the names from the right-hand side of the ParameterDef type
		/// </summary>
		List<string> parameterNamesList = new List<string>();

		/// <summary>
		/// List of all loaded functions
		/// </summary>
		List<FunctionDef> LoadedFunctionsList = new List<FunctionDef>();

		/// <summary>
		/// Stores the current function prior to any changes
		/// </summary>
		FunctionDef currentEdittingBackup = new FunctionDef();

		ExamplesWindow exampleWindowInstance = null;
		#endregion


		FunctionDef currentFunctionDef;


		public MainWindow()
		{
			InitializeComponent();
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
			populateFunctionListBox(JsonConvert.DeserializeObject<List<FunctionDef>>(file.ReadToEnd()));
			updateParameterTypeLists();
		}

		/// <summary>
		/// Updates the ParameterDef type and name lists from all parameters
		/// </summary>
		private void updateParameterTypeLists()
		{
			foreach (FunctionDef f in LoadedFunctionsList)
			{
				if (f.Parameters != null)
				{
					foreach (ParameterDef p in f.Parameters)
					{
						string[] s = p.type.Split(':');
						if (!parameterTypesList.Contains(s[0]) && !String.IsNullOrEmpty(s[0])) { parameterTypesList.Add(s[0]); }
						if (s.Length >= 2 && !parameterNamesList.Contains(s[1]) && !String.IsNullOrEmpty(s[1])) { parameterNamesList.Add(s[1]); }
					}
				}
			}
			comboBoxReturnTypeURL.Items.Clear();
			comboBoxReturnTypeURL.Items.AddRange(parameterURLList.ToArray());
			comboBoxReturnTypeType.Items.Clear();
			comboBoxReturnTypeType.Items.AddRange(parameterTypesList.ToArray());
			comboBoxReturnTypeName.Items.Clear();
			comboBoxReturnTypeName.Items.AddRange(parameterNamesList.ToArray());
		}

		/// <summary>
		/// Takes a list of function objects and adds their names to the listbox form.
		/// </summary>
		/// <param name="functionList">A List&lt;T&gt; of FunctionDefs that will be added to the working list of functions.</param>
		private void populateFunctionListBox(List<FunctionDef> functionList)
		{
			if (functionList != null)
			{
				foreach (FunctionDef f in functionList)
				{
					addToFunctionListBox(f);
				}
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
		/// Resets the entire form to the state of program start
		/// </summary>
		private void clearEntireForm()
		{
			listboxFunctionList.Items.Clear();
			LoadedFunctionsList.Clear();
			parameterNamesList.Clear();
			parameterTypesList.Clear();
			parametersList.Clear();
			currentEdittingBackup = new FunctionDef();
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
			checkBoxReturnType.Checked = false;
			checkBoxConditional.Checked = false;
		}

		private bool hasChanged()
		{
			FunctionDef toCheck = windowToFunction(new FunctionDef());
			if (toCheck.Equals(currentEdittingBackup))
				return false;
			return true;
		}


	#region Reusable Form Functions
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
			form.StartPosition = FormStartPosition.CenterParent;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}
	#endregion

	#region Function Panel

		#region Events
			/// <summary>
			/// Enables the Save button only when a function name has been entered
			/// </summary>
			private void textBoxName_TextChanged(object sender, EventArgs e)
			{
				System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)sender;
				if (String.IsNullOrEmpty(t.Text) || String.IsNullOrWhiteSpace(t.Text))
					buttonSaveCurrentChanges.Enabled = false;
				else
					buttonSaveCurrentChanges.Enabled = true;
			}

			private void buttonNewParameter_Click(object sender, EventArgs e)
			{
				Control c = new Parameter(parameterURLList.ToArray(), parameterTypesList.ToArray(), parameterNamesList.ToArray());
				parametersList.Add(c);
				flowLayoutPanelParameters.Controls.Add(c);
			}

			/// <summary>
			/// Copy a Parameter and add it to the panel. Then recalculate the numbers of all Parameters
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void buttonCopyParameter_Click(object sender, EventArgs e)
			{
				Control newParam = new Parameter((Parameter)(System.Windows.Forms.GroupBox)parametersList.Last());
				parametersList.Add(newParam);
				flowLayoutPanelParameters.Controls.Add(newParam);
			}

			/// <summary>
			/// Toggles the fields in the return type group.
			/// </summary>
			private void checkBoxReturnType_CheckedChanged(object sender, EventArgs e)
			{
				System.Windows.Forms.CheckBox box = (System.Windows.Forms.CheckBox)sender;

				foreach (Control c in box.Parent.Controls)
				{
					if (c != box)
					{
						if (c.Enabled == true)
							c.Enabled = false;
						else
							c.Enabled = true;
					}
				}
			}

			/// <summary>
			/// Save all the form data and add the function as a new function to the list box
			/// </summary>
			private void buttonSaveCurrentChanges_Click(object sender, EventArgs e)
			{
				if (!LoadedFunctionsList.Exists(f => f.Name == textBoxName.Text))
				{
					saveNewFunction();
				}
				else
				{
					// Update existing function
					DialogResult d = MessageBox.Show("This function already exists. Would you like to update it with the new information?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (d == DialogResult.Yes)
						updateCurrentFunction(); // Update existing function
				} // end else
				updateParameterTypeLists();
			} // end buttonSaveCurrentChanges_Click

			/// <summary>
			/// Reverts changes to the state when the form was loaded
			/// If working at start, will produce a clean form
			/// If working on an existing function will revert to pre-edit
			/// </summary>
			private void buttonDiscardChanges_Click(object sender, EventArgs e)
			{
				DialogResult d = MessageBox.Show("Are you sure you want to discard the changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (d == DialogResult.Yes)
					populateFunctionForm(currentEdittingBackup);
			}

			/// <summary>
			/// Prompts to ensure the user wants to clear the form, then clears all form entry if yes
			/// </summary>
			private void buttonNewFunction_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Are you sure you want to clear the form?", "New Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d == DialogResult.Yes)
				populateFunctionForm(new FunctionDef());
		}

		#endregion Events

		/// <summary>
		/// Creates a ParameterDef list and populates all the groupboxes with
		/// the values from a function's parameters
		/// </summary>
		/// <param name="paramList">List of parameters</param>
		private void populateParameterList(List<ParameterDef> parameterList)
			{
				if (parameterList != null)
				{
					foreach (ParameterDef parameter in parameterList)
					{
						//Control c = new Parameter(parameterURLList.ToArray(), parameterTypesList.ToArray(), parameterNamesList.ToArray());
						Control c = new Parameter(
							parameter.url,
							parameter.type,
							parameter.optional,
							parameterURLList.ToArray(),
							parameterTypesList.ToArray(),
							parameterNamesList.ToArray()
						);

						parametersList.Add(c);
						flowLayoutPanelParameters.Controls.Add(c);
					}
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
			checkBoxReturnType.Checked = false;
			checkBoxConditional.Checked = false;

			// save the settings to a global first, so we can revert if a bad change is made
			currentEdittingBackup = func;

			textBoxName.Text = func.Name;
			textBoxAlias.Text = func.Alias;
			textBoxVersion.Text = func.Version;
			textBoxOrigin.Text = func.FromPlugin;
			textBoxCategory.Text = func.Category;

			if (func.Tags != null)
				foreach (string s in func.Tags) { textBoxTags.Text += s + System.Environment.NewLine; }

			switch (func.Convention)
			{
				case "B": radioButtonCallingConventionBase.Checked = true; break;
				case "E": radioButtonCallingConventionEither.Checked = true; break;
				case "R": radioButtonCallingConventionRef.Checked = true; break;
				default: radioButtonCallingConventionEither.Checked = true; break;
			}

			// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
			switch (func.Condition)
			{
				case "True": checkBoxConditional.Checked = true; break;
				default: checkBoxConditional.Checked = false; break;
			}

			populateParameterList(func.Parameters);

			switch (func.ReturnType == null)
			{
				case true:
					comboBoxReturnTypeURL.Text = "";
					comboBoxReturnTypeType.Text = "";
					comboBoxReturnTypeName.Text = "";
					checkBoxReturnType.Checked = false;
					break;
				default:
					comboBoxReturnTypeURL.Text = func.ReturnType[0].type;
					string[] s = func.ReturnType[0].type.Split(':');
					if (s.Length >= 1) { comboBoxReturnTypeType.Text = s[0]; }
					if (s.Length >= 2) { comboBoxReturnTypeName.Text = s[1]; }
					checkBoxReturnType.Checked = true;
					break;
			}

			if (func.Description != null)
				foreach (string s in func.Description) { richTextBoxDescription.Text += s + System.Environment.NewLine + System.Environment.NewLine; }
		}

		/// <summary>
		/// Converts the window data into a function object
		/// </summary>
		/// <param name="functionToAdd">A function that will be returned filled with the data in the window.</param>
		private FunctionDef windowToFunction(FunctionDef function)
		{
			if (!String.IsNullOrEmpty(textBoxName.Text)) { function.Name = textBoxName.Text; }
			if (!String.IsNullOrEmpty(textBoxAlias.Text)) { function.Alias = textBoxAlias.Text; }
			else { function.Alias = null; }
			if (!String.IsNullOrEmpty(textBoxVersion.Text)) { function.Version = textBoxVersion.Text; }
			else { function.Version = null; }
			if (!String.IsNullOrEmpty(textBoxOrigin.Text)) { function.FromPlugin = textBoxOrigin.Text; }
			else { function.FromPlugin = null; }
			if (!String.IsNullOrEmpty(textBoxCategory.Text)) { function.Category = textBoxCategory.Text; }
			else { function.Category = null; }

			if (!String.IsNullOrEmpty(textBoxTags.Text))
			{
				foreach (string line in textBoxTags.Lines)
				{
					if (function.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line)) { function.Tags.Add(line); }
				}
			}

			if (radioButtonCallingConventionBase.Checked == true) { function.Convention = "B"; }
			else if (radioButtonCallingConventionEither.Checked == true) { function.Convention = "E"; }
			else if (radioButtonCallingConventionRef.Checked == true) { function.Convention = "R"; }


			// TODO: Update javascript to handle true/false
			if (checkBoxConditional.Checked == true) { function.Condition = checkBoxConditional.Checked.ToString(); }
			else { function.Condition = null; }

			if (parametersList.Count > 0 && function.Parameters == null)
			{
				function.Parameters = new List<ParameterDef>();
				function.Parameters.Clear();
				foreach (Parameter c in parametersList)
				{
					ParameterDef newParam = new ParameterDef();

					if (!String.IsNullOrEmpty(c.Url)) { newParam.url = c.Url; }
					if (!String.IsNullOrEmpty(c.Type)) { newParam.type = c.Type; }
					if (!String.IsNullOrEmpty(c.Optional))
						if(c.Optional.ToLower().Equals("true"))
							newParam.optional = c.Optional;

					function.Parameters.Add(newParam);
				}
			}
			else { function.Parameters = null; }

			if (checkBoxReturnType.Checked)
			{
				if (function.ReturnType == null) { function.ReturnType = new List<ReturnTypeDef>(); function.ReturnType.Add(new ReturnTypeDef()); }
				if (!String.IsNullOrEmpty(comboBoxReturnTypeURL.Text)) { function.ReturnType[0].type = comboBoxReturnTypeURL.Text; }
				string s = comboBoxReturnTypeType.Text + ":" + comboBoxReturnTypeName.Text;
				if (!String.IsNullOrEmpty(s)) { function.ReturnType[0].type = s; }
			}

			if (!String.IsNullOrEmpty(richTextBoxDescription.Text))
			{
				if (function.Description == null) { function.Description = new List<string>(); }
				function.Description.Clear();
				foreach (string line in richTextBoxDescription.Lines)
				{
					if (function.Description.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
						function.Description.Add(line);
				}
			}

			return function;
		}


	#endregion

		private void setFocus(object sender)
		{
			((System.Windows.Forms.Control)sender).Focus();
		}

		private void clearFocus(object sender)
		{
			labelName.Focus();
		}


	#region Events

	#region Mouse Event Handlers
		// Update the mouse event label to indicate the MouseEnter event occurred.
		private void formMouseEventHandler_MouseEnter(object sender, System.EventArgs e)
		{
			string s = "";
			if (sender == textBoxName)
				s = "Enter the name of the function";

			else if (sender == textBoxAlias)
				s = "Enter the alternate name of the function. Leave blank if none";

			else if (sender == textBoxVersion)
				s = "The version of NVSE this funtion was added in";

			else if (sender == radioButtonCallingConventionRef)
				s = "A function called by reference: ref.Function";

			else if (sender == radioButtonCallingConventionBase)
				s = "A function called by base form: Function Object";

			else if (sender == radioButtonCallingConventionEither)
				s = "A function called by either of the above. Most functions work this way";

			else if (sender == checkBoxConditional)
				s = "If this function can be used as a conditional in the condition dialog";

			else if (sender == textBoxTags)
				s = "Any other means of searching this function. Ex. Array, String, Inventory";

			else if (sender == textBoxOrigin)
				s = "The plugin of origin of the function. Leave blank if it is an NVSE function";

			else if (sender == textBoxCategory)
				s = "The class type of the function";

			else
				s = "";

			outputToStatusbar(s);
		}

		// Update the mouse event label to indicate the MouseHover event occurred.
		private void formMouseEventHandler_MouseHover(object sender, System.EventArgs e)
		{

		}

		// Update the mouse event label to indicate the MouseLeave event occurred.
		private void formMouseEventHandler_MouseLeave(object sender, System.EventArgs e)
		{
			outputToStatusbar("");
		}

		// When mouse enters flowLayout panel, set focus so scroll wheel works
		private void flowLayoutPanelParameters_MouseEnter(object sender, EventArgs e)
		{
			outputToStatusbar("A list of parameters for the function");
			flowLayoutPanelParameters.Focus();
		}
		#endregion

	#region Tool Strip Handlers

		string fileName;

		private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
			openFileDialog1.Multiselect = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				clearEntireForm();
				foreach (String file in openFileDialog1.FileNames)
				{
					StreamReader sr = new StreamReader(file);
					parseLoadedFile(sr);
					sr.Close();
				}
				fileName = openFileDialog1.SafeFileName;
			}
		}

		private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
			saveFileDialog1.FileName = fileName;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile());
				JsonSerializerSettings settings = new JsonSerializerSettings()
				{
					Formatting = Formatting.None,
					DefaultValueHandling = DefaultValueHandling.Ignore,
					NullValueHandling = NullValueHandling.Ignore,
				};


				sw.Write(JsonConvert.SerializeObject(LoadedFunctionsList, settings));
				sw.Close();
			}
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			clearEntireForm();
		} 

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (confirmCloseForm() == DialogResult.Yes)
				System.Windows.Forms.Application.Exit();
		}

		/// <summary>
		/// When closing the form, ask if data has been saved before allowing an exit
		/// </summary>
		private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
#if !DEBUG
			if (confirmCloseForm() == DialogResult.No)
				e.Cancel = true;
#endif
		}
		#endregion

	#region Function List Events

		/// <summary>
		/// Uses MouseUp event to catch when the selcted count changes.
		/// Checks how many are selected and enables the editing buttons.
		/// </summary>
		private void listboxFunctionList_MouseUp(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				if (listboxFunctionList.SelectedItems.Count > 1)
				{
					buttonListBoxDeleteItem.Enabled = true;
					buttonListBoxChangeCategory.Enabled = true;
				}
				else
				{
					buttonListBoxDeleteItem.Enabled = true;
					buttonListBoxChangeCategory.Enabled = false;
				}
			}
		}

		/// <summary>
		/// On double click a name in the list box, load the function data into the fields
		/// </summary>
		private void listboxFunctionList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				currentFunctionDef = LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItem.ToString());
				populateFunctionForm(currentFunctionDef);
			}
		}

		/// <summary>
		/// Delete the selected functions from the functions list and listbox
		/// </summary>
		private void buttonListBoxDeleteItem_Click(object sender, EventArgs e)
		{
			if (listboxFunctionList.SelectedItems.Count > 0)
			{
				DialogResult d = MessageBox.Show("Are you sure you want to delete the selected function?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (d == DialogResult.Yes)
				{
					for (int i = listboxFunctionList.SelectedItems.Count - 1; i >= 0; i--)
					{
						LoadedFunctionsList.Remove(LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItems[i].ToString()));
						listboxFunctionList.Items.Remove(listboxFunctionList.SelectedItems[i]);
					}



					//List<string> names = new List<string>();
					//foreach (string s in listboxFunctionList.SelectedItems)
					//{
					//	FunctionDef func = LoadedFunctionsList.Find(f => f.Name == s);
					//	LoadedFunctionsList.Remove(func);
					//	listboxFunctionList.Items.RemoveAt(listboxFunctionList.SelectedItems.IndexOf(s));
					//} // end foreach

				} // end dialog if
			} // end size if
		}

		/// <summary>
		/// Bulk change the category of all selected functions.
		/// </summary>
		private void buttonListBoxChangeCategory_Click(object sender, EventArgs e)
		{
			string input = "";
			DialogResult d = InputBox("Change Category", "Enter the new Category", ref input);

			// decided to bulk change category on selected functions
			if (d == DialogResult.OK)
			{
				foreach (string s in listboxFunctionList.SelectedItems)
				{
					LoadedFunctionsList.Find(f => f.Name == s).Category = input;
				}
			}
		}

		private void listboxFunctionList_MouseEnter(object sender, EventArgs e)
		{
			setFocus(sender);
		}

		private void listboxFunctionList_MouseLeave(object sender, EventArgs e)
		{
			clearFocus(sender);
		}
	#endregion Function List Events

		private void buttonShowExamples_Click(object sender, EventArgs e)
		{
			if (exampleWindowInstance == null || exampleWindowInstance.IsDisposed)
				exampleWindowInstance = new ExamplesWindow();
			exampleWindowInstance.Show();

			if (exampleWindowInstance.Focused == false)
				exampleWindowInstance.Focus();
		}

	#endregion Events


		

	}
}
