using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{

		ExamplesWindow _exampleWindowInstance = null;
		string _fileName;

		public MainWindow()
		{
			InitializeComponent();
		}


		private void WikiParser()
		{
			string rawFunction = richTextBoxDescription.Text;

			// removes the "See Also" section and anything below it
			var seeAlso = new Regex(@"(==[']*See Also[']*==.*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			rawFunction = seeAlso.Replace(rawFunction, "");

			// for pages without the "See Also" section, remove the block of additional links
			var linkBreaker = new Regex(@"^((\[\[)(\w*):(\w*)([\s\w\W]*?)(\]\]))$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			rawFunction = linkBreaker.Replace(rawFunction, "");

			// sets instances of double curlies to a single brace with a line break between
			var replaceCurlies = new Regex(@"}}{{", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			rawFunction = replaceCurlies.Replace(rawFunction, "}\n{");

			// gets each section of the page under any headings
			var dataGrabber = new Regex(@"([=]{2,5}[']*[\w\s]*[']*[=]{2,5})(.*?)([=]{2,5}[']*[\w\s]*[']*[=]{2,5})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			string[] parts = dataGrabber.Split(rawFunction);

			string[] functionParts = parts[0].Split('|','}');

			for (int index = 0; index < functionParts.Length; index++)
			{
				functionParts[index] = functionParts[index].Trim();
			}

			foreach (var str in parts)
			{
				MessageBox.Show(str);
			}

			#region parse

			/*var stck = new Stack<string>();
			bool functionArgumentFound = false;
			foreach (string line in s.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
			{
				string f="", l="";
				string[] parts = line.Split('=');

				if (parts.Any())
				{
					f = parts[0].Trim();
					f = f.Remove(0, 1);
				}

				if (parts.Count() >= 2)
					l = parts[1].Trim();


				if (functionArgumentFound == true)
				{
					stck.Push(f);
					stck.Push(l);
				}

				if (f.Contains("FunctionArgument") || l.Contains("FunctionArgument"))
					functionArgumentFound = true;



				if (f.Contains("origin"))
					textBoxOrigin.Text = "Geck";

				if (f.Contains("summary"))
					richTextBoxDescription.Text = l;

				if (f == "returnType")
					checkBoxReturnType.Checked = true;

				if (f.Contains("name"))
					textBoxName.Text = l;*/

			#endregion

		}





		/// <summary>
		/// Outputs a string to the statusbar
		/// </summary>
		/// <param name="outString">A string of text to explain what the current action is.</param>
		private void OutputToStatusbar(string outString)
		{
			toolStripStatusLabel1.Text = outString;
		}

		/// <summary>
		/// Turns a json encoded StreamReader file object into a list of FunctionDef objects.
		/// </summary>
		/// <param name="file">An input file object formatted in json.</param>
		private void ParseLoadedFile(StreamReader file)
		{
			PopulateFunctionListBox(JsonConvert.DeserializeObject<List<FunctionDef>>(file.ReadToEnd()));
			UpdateParameterTypeLists();
		}
		/// <summary>
		/// Updates the ParameterDef type and name lists from all parameters
		/// </summary>
		private void UpdateParameterTypeLists()
		{
			foreach (var s in from f in Variables.LoadedFunctionsList where f.Parameters != null from p in f.Parameters where p.Type != null select p.Type.Split(':'))
			{
				if (!Variables.ParameterTypesList.Contains(s[0]) && !String.IsNullOrEmpty(s[0])) { Variables.ParameterTypesList.Add(s[0]); }
				if (s.Length >= 2 && !Variables.ParameterNamesList.Contains(s[1]) && !String.IsNullOrEmpty(s[1])) { Variables.ParameterNamesList.Add(s[1]); }
			}
			comboBoxReturnTypeURL.Items.Clear();
			comboBoxReturnTypeURL.Items.AddRange(Variables.ParameterUrlList.ToArray());
			comboBoxReturnTypeType.Items.Clear();
			comboBoxReturnTypeType.Items.AddRange(Variables.ParameterTypesList.ToArray());
			comboBoxReturnTypeName.Items.Clear();
			comboBoxReturnTypeName.Items.AddRange(Variables.ParameterNamesList.ToArray());
		}

		/// <summary>
		/// Takes a list of function objects and adds their names to the listbox form.
		/// </summary>
		/// <param name="functionList">A List&lt;T&gt; of FunctionDefs that will be added to the working list of functions.</param>
		private void PopulateFunctionListBox(List<FunctionDef> functionList)
		{
			if (functionList != null)
				foreach (FunctionDef f in functionList)
					AddToFunctionListBox(f);
			RebuildParamaterPanel();
		}

		/// <summary>
		/// Checks if a function exists in the list and, if it's not, adds it to the list and updates the listbox
		/// </summary>
		/// <param name="functionToAdd">A function to add to the list of loaded functions</param>
		private void AddToFunctionListBox(FunctionDef functionToAdd)
		{
			if (!Variables.LoadedFunctionsList.Exists(n => n.Name == functionToAdd.Name))
			{
				listboxFunctionList.Items.Add(functionToAdd.Name);
				Variables.LoadedFunctionsList.Add(functionToAdd);
			}
		}

		/// <summary>
		/// Resets the entire form to the state of program start
		/// </summary>
		private void ClearEntireForm()
		{
			Variables.LoadedFunctionsList.Clear();
			Variables.ParameterNamesList.Clear();
			Variables.ParameterTypesList.Clear();
			Variables.ParametersList.Clear();
			Variables.ParametersList.Clear();
			Variables.CurrentEditingBackup = new FunctionDef();
			listboxFunctionList.Items.Clear();
			flowLayoutPanelParameters.Controls.Clear();
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
				Control c = new Parameter(Variables.ParameterUrlList.ToArray(), Variables.ParameterTypesList.ToArray(), Variables.ParameterNamesList.ToArray());
				Variables.ParametersList.Add(c);
				flowLayoutPanelParameters.Controls.Add(c);
				RebuildParamaterPanel();
			}

			/// <summary>
			/// Copy a Parameter and add it to the panel. Then recalculate the numbers of all Parameters
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void buttonCopyParameter_Click(object sender, EventArgs e)
			{
				Control newParam = new Parameter((Parameter)(System.Windows.Forms.GroupBox)Variables.ParametersList.Last());
				Variables.ParametersList.Add(newParam);
				flowLayoutPanelParameters.Controls.Add(newParam);
				RebuildParamaterPanel();
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
				if (!Variables.LoadedFunctionsList.Exists(f => f.Name == textBoxName.Text))
				{
					SaveNewFunction();
				}
				else
				{
					// Update existing function
					DialogResult d = MessageBox.Show("This function already exists. Would you like to update it with the new information?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (d == DialogResult.Yes)
						UpdateCurrentFunction(); // Update existing function
				} // end else
				UpdateParameterTypeLists();
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
					if (Variables.CurrentEditingBackup == null)
						PopulateFunctionForm(new FunctionDef());
					else
						PopulateFunctionForm(Variables.CurrentEditingBackup);
			}

			/// <summary>
			/// Prompts to ensure the user wants to clear the form, then clears all form entry if yes
			/// </summary>
			private void buttonNewFunction_Click(object sender, EventArgs e)
		{
			WikiParser();
			DialogResult d = MessageBox.Show("Are you sure you want to clear the form?", "New Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d == DialogResult.Yes)
				PopulateFunctionForm(new FunctionDef());
		}

			private void buttonShowExamples_Click(object sender, EventArgs e)
			{
				if (_exampleWindowInstance == null || _exampleWindowInstance.IsDisposed)
					_exampleWindowInstance = new ExamplesWindow();
				_exampleWindowInstance.Show();

				if (_exampleWindowInstance.Focused == false)
					_exampleWindowInstance.Focus();
			}
		#endregion Events

		/// <summary>
		/// Takes a function and fills in all the window fields
		/// with their appropriate data
		/// </summary>
		public void PopulateFunctionForm(FunctionDef func)
		{
			flowLayoutPanelParameters.Controls.Clear();
			Variables.ParametersList.Clear();
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
			Variables.CurrentEditingBackup = func;
			Variables.ExampleList = func.ExampleList;

			if (_exampleWindowInstance != null)
				_exampleWindowInstance.PopulateForm();

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

			PopulateParameterList(func.Parameters);

			switch (func.ReturnType == null)
			{
				case true:
					comboBoxReturnTypeURL.Text = "";
					comboBoxReturnTypeType.Text = "";
					comboBoxReturnTypeName.Text = "";
					checkBoxReturnType.Checked = false;
					break;
				default:
					comboBoxReturnTypeURL.Text = func.ReturnType[0].Type;
					string[] s = func.ReturnType[0].Type.Split(':');
					if (s.Length >= 1) { comboBoxReturnTypeType.Text = s[0]; }
					if (s.Length >= 2) { comboBoxReturnTypeName.Text = s[1]; }
					checkBoxReturnType.Checked = true;
					break;
			}

			if (func.Description != null)
				foreach (string s in func.Description) { richTextBoxDescription.Text += System.Web.HttpUtility.HtmlDecode(s) + System.Environment.NewLine + System.Environment.NewLine; }
		}

		/// <summary>
		/// Creates a ParameterDef list and populates all the groupboxes with
		/// the values from a function's parameters
		/// </summary>
		/// <param name="paramList">List of parameters</param>
		private void PopulateParameterList(List<ParameterDef> parameterList)
			{
				if (parameterList != null)
				{
					foreach (ParameterDef parameter in parameterList)
					{
						//Control c = new Parameter(Variables.parameterURLList.ToArray(), Variables.parameterTypesList.ToArray(), Variables.parameterNamesList.ToArray());
						Control c = new Parameter(
							parameter.Url,
							parameter.Type,
							parameter.Optional,
							Variables.ParameterUrlList.ToArray(),
							Variables.ParameterTypesList.ToArray(),
							Variables.ParameterNamesList.ToArray()
						);

						Variables.ParametersList.Add(c);
						flowLayoutPanelParameters.Controls.Add(c);
					}
					RebuildParamaterPanel();
				}
			}

		/// <summary>
		/// Renumbers the groupbox text on all groupboxes in the ParameterDef list
		/// </summary>
		private void RebuildParamaterPanel()
		{
			for (int i = 0; i < flowLayoutPanelParameters.Controls.Count; i++)
			{
				flowLayoutPanelParameters.Controls[i].Text = "Parameter " + (i + 1).ToString();
			}
		}

		/// <summary>
		/// Converts the window data into a function object
		/// </summary>
		/// <param name="functionToAdd">A function that will be returned filled with the data in the window.</param>
		private FunctionDef WindowToFunction(FunctionDef function)
		{
			if (!String.IsNullOrEmpty(textBoxName.Text)) { function.Name = textBoxName.Text; }
			function.Alias = !String.IsNullOrEmpty(textBoxAlias.Text) ? textBoxAlias.Text : null;
			function.Version = !String.IsNullOrEmpty(textBoxVersion.Text) ? textBoxVersion.Text : null;
			function.FromPlugin = !String.IsNullOrEmpty(textBoxOrigin.Text) ? textBoxOrigin.Text : null;
			function.Category = !String.IsNullOrEmpty(textBoxCategory.Text) ? textBoxCategory.Text : null;


			if (!String.IsNullOrEmpty(textBoxTags.Text))
			{
				// if the tag variable is null, and there are tags to put in it, create a new list
				if (function.Tags == null)
					function.Tags = new List<string>();

				// step through each line in the text box, each line is a tag, and store each one
				// in the list. If there is an empty line, or the line exists already, skip it.
				foreach (var line in textBoxTags.Lines)
				{
					if (function.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
					{
						function.Tags.Add(line);
					}
				}
			}

			if (radioButtonCallingConventionBase.Checked == true) { function.Convention = "B"; }
			else if (radioButtonCallingConventionEither.Checked == true) { function.Convention = "E"; }
			else if (radioButtonCallingConventionRef.Checked == true) { function.Convention = "R"; }


			// TODO: Update javascript to handle true/false
			function.Condition = checkBoxConditional.Checked == true ? checkBoxConditional.Checked.ToString() : null;

			if (Variables.ParametersList.Count > 0)
			{
				function.Parameters = new List<ParameterDef>();
				function.Parameters.Clear();
				foreach (Parameter c in Variables.ParametersList)
				{
					var newParam = new ParameterDef();

					if (!String.IsNullOrEmpty(c.Url)) { newParam.Url = c.Url; }
					if (!String.IsNullOrEmpty(c.Type) && c.Type != ":") { newParam.Type = c.Type; }
					if (!String.IsNullOrEmpty(c.Optional))
						if(c.Optional.ToLower().Equals("true"))
							newParam.Optional = c.Optional;

					function.Parameters.Add(newParam);
				}
			}
			else { function.Parameters = null; }

			if (checkBoxReturnType.Checked)
			{
				if (function.ReturnType == null) { function.ReturnType = new List<ReturnTypeDef>(); function.ReturnType.Add(new ReturnTypeDef()); }
				if (!String.IsNullOrEmpty(comboBoxReturnTypeURL.Text)) { function.ReturnType[0].Type = comboBoxReturnTypeURL.Text; }
				string s = comboBoxReturnTypeType.Text + ":" + comboBoxReturnTypeName.Text;
				if (!String.IsNullOrEmpty(s)) { function.ReturnType[0].Type = s; }
			}

			if (Variables.ExampleList != null)
			{
				foreach(Example e in Variables.ExampleList)
				{
					if (e.Contents == null)
						Variables.ExampleList.Remove(e);
				}
				function.ExampleList = Variables.ExampleList;
			}

			if (!String.IsNullOrEmpty(richTextBoxDescription.Text))
			{
				if (function.Description == null) { function.Description = new List<string>(); }
				function.Description.Clear();
				foreach (string line in richTextBoxDescription.Lines)
				{
					if (function.Description.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
						function.Description.Add(System.Web.HttpUtility.HtmlEncode(line));
				}
			}

			return function;
		}

		/// <summary>
		/// Takes all the info in the window and creates a new function from it
		/// then adds it to the listbox and Variables.LoadedFunctionsList
		/// </summary>
		private void SaveNewFunction()
		{
			FunctionDef func = WindowToFunction(new FunctionDef());
			AddToFunctionListBox(func);
		}

		/// <summary>
		/// Finds the current function by name and replaces its data with that in the window
		/// </summary>
		private void UpdateCurrentFunction()
		{
			WindowToFunction(Variables.LoadedFunctionsList.Find(f => f.Name == textBoxName.Text));
		}

	#endregion

	#region Function List

		#region Events
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
				LoadSelectedFunction();
			}

			/// <summary>
			/// Delete the selected functions from the functions list and listbox
			/// </summary>
			private void buttonListBoxDeleteItem_Click(object sender, EventArgs e)
			{
				if (listboxFunctionList.SelectedItems.Count > 0)
				{
					if (Common.ConfirmDelete("function(s)") == DialogResult.Yes)
					{
						for (int i = listboxFunctionList.SelectedItems.Count - 1; i >= 0; i--)
						{
							Variables.LoadedFunctionsList.Remove(Variables.LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItems[i].ToString()));
							listboxFunctionList.Items.Remove(listboxFunctionList.SelectedItems[i]);
						}
					}
				}
			}

			/// <summary>
			/// Bulk change the category of all selected functions.
			/// </summary>
			private void buttonListBoxChangeCategory_Click(object sender, EventArgs e)
			{
				string input = "";
				DialogResult d = Common.InputBox("Change Category", "Enter the new Category", ref input);

				// decided to bulk change category on selected functions
				if (d == DialogResult.OK)
				{
					foreach (string s in listboxFunctionList.SelectedItems)
					{
						Variables.LoadedFunctionsList.Find(f => f.Name == s).Category = input;
					}
				}
			}

			/// <summary>
			/// Handles key presses for listboxFunctionList
			/// </summary>
			private void listboxFuctionList_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					buttonListBoxDeleteItem_Click(sender, e);
					break;
				case Keys.Enter:
					LoadSelectedFunction();
					break;
				default:
					break;
			}
		}
		#endregion

		/// <summary>
		/// Loads the function data from the selected index by name
		/// </summary>
		private void LoadSelectedFunction()
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				PopulateFunctionForm(Variables.LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItem.ToString()));
			}
		}


	#endregion Function List

	#region Events

	#region Mouse Event Handlers
		// Update the mouse event label to indicate the MouseEnter event occurred.
		private void formMouseEventHandler_MouseEnter(object sender, System.EventArgs e)
		{
			var s = "";
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

			else if (sender == groupSelectionEditor)
				s = "";

			else
				s = "";

			OutputToStatusbar(s);
		}

		// Update the mouse event label to indicate the MouseHover event occurred.
		private void formMouseEventHandler_MouseHover(object sender, System.EventArgs e)
		{

		}

		// Update the mouse event label to indicate the MouseLeave event occurred.
		private void formMouseEventHandler_MouseLeave(object sender, System.EventArgs e)
		{
			OutputToStatusbar("");
		}

		// When mouse enters flowLayout panel, set focus so scroll wheel works
		private void flowLayoutPanelParameters_MouseEnter(object sender, EventArgs e)
		{
			flowLayoutPanelParameters.Focus();
		}
		#endregion

	#region Tool Strip Handlers

		private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = @"Json Files (.json)|*.json|Text Files(*.*)|*.*";
			openFileDialog1.Multiselect = true;
			switch (openFileDialog1.ShowDialog())
			{
				case DialogResult.OK:
					ClearEntireForm();
					foreach (var sr in openFileDialog1.FileNames.Select(file => new StreamReader(file)))
					{
						ParseLoadedFile(sr);
						sr.Close();
					}
					_fileName = openFileDialog1.SafeFileName;
					break;
			}
		}

		private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = @"Json Files (.json)|*.json|Text Files(*.*)|*.*";
			saveFileDialog1.FileName = _fileName;
			switch (saveFileDialog1.ShowDialog())
			{
				case DialogResult.OK:
				{
					var sw = new StreamWriter(saveFileDialog1.OpenFile());
					var settings = new JsonSerializerSettings()
					{
						Formatting = Formatting.None,
						DefaultValueHandling = DefaultValueHandling.Ignore,
						NullValueHandling = NullValueHandling.Ignore,
					};

					if (outputReadableFileToolStripMenuItem.Checked == true)
						settings.Formatting = Formatting.Indented;

					foreach (var f in Variables.LoadedFunctionsList)
					{
						f.CleanFunctionDef();
					}
					sw.Write(JsonConvert.SerializeObject(Variables.LoadedFunctionsList, settings));
					sw.Close();
				}
					break;
			}
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearEntireForm();
		} 

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Common.ConfirmCloseForm() == DialogResult.Yes)
				System.Windows.Forms.Application.Exit();
		}

		private void checkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			switch (((ToolStripMenuItem)sender).Checked)
			{
				case true:
					((ToolStripMenuItem)sender).Checked = false;
					break;
				default:
					((ToolStripMenuItem)sender).Checked = true;
					break;
			}
		}

		/// <summary>
		/// When closing the form, ask if data has been saved before allowing an exit
		/// </summary>
		private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
#if !DEBUG
			if (Common.ConfirmCloseForm() == DialogResult.No)
				e.Cancel = true;
#endif
		}
		#endregion

		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{

		}

	#endregion Events

	}
}
