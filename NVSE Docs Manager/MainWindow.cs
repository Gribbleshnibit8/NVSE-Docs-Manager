using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{
		/// <summary>
		/// Instance of the Exampel Window used to ensure only one window exists.
		/// </summary>
		ExamplesWindow _exampleWindowInstance = null;

		/// <summary>
		/// The name of the first file we opened.
		/// </summary>
		string _fileName;

		Variables _instanceVariables = new Variables();

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

			// get the function definition data out for further parsing
			var functionParts = new List<string>(parts[0].Split('|','}'));

			// clear all new
			for (int index = 0; index < functionParts.Count; index++)
			{
				// remove excess spaces and newlines
				functionParts[index] = functionParts[index].Trim();

				// remove inline newlines except in summary
				if (functionParts[index].Contains("\n") && !functionParts[index].Contains("summary"))
					functionParts[index] = functionParts[index].Replace("\n", "");

				// remove empty lines or lines that are only newlines
				if (String.IsNullOrEmpty(functionParts[index]) || functionParts[index] == "\n")
				{
					functionParts.RemoveAt(index);
					index--;
				}
			}

			// fill text boxes in form
			if (functionParts.Find(s => s.ToLower().Contains("name")).Split('=').Length > 1)
				textBoxName.Text = functionParts.Find(s => s.ToLower().Contains("name")).Split('=')[1].Trim();
			if (!string.IsNullOrEmpty(functionParts.Find(s => s.ToLower().Contains("alias"))))
				if (functionParts.Find(s => s.ToLower().Contains("alias")).Split('=').Length > 1)
					textBoxAlias.Text = functionParts.Find(s => s.ToLower().Contains("alias")).Split('=')[1].Trim();
			if (functionParts.Find(s => s.ToLower().Contains("origin")).Split('=').Length > 1)
			{
				string t = functionParts.Find(s => s.ToLower().Contains("origin")).Split('=')[1].Trim();
				textBoxVersion.Text = t;
				textBoxOrigin.Text = t;
				textBoxTags.Text = t;
			}

			// TODO: Remove triple apostrophe groups
			if (functionParts.Find(s => s.ToLower().Contains("summary")).Split('=').Length > 1)
				richTextBoxDescription.Text = functionParts.Find(s => s.ToLower().Contains("summary")).Split('=')[1].Trim();
			richTextBoxDescription.AppendText("\n\n");

			// TODO: write extra function to parse multiline examples into separate example lists
			//Variables.ExampleList = new List<Example>();
			//Variables.ExampleList.Add(new Example(functionParts.Find(s => s.ToLower().Contains("origin")).Split('=')[1].Trim()));



			// get the parameters, and add them to the flowLayoutPanel
			for (int index = 0; index < functionParts.Count; index++)
			{
				if (functionParts[index].ToLower().Contains("functionargument"))
				{
					int nextIndex = functionParts.FindIndex(index + 1, f => f.ToLower().Contains("functionargument"));
					if (nextIndex == -1) nextIndex = functionParts.Count;

					var param = new ParameterDef();
					var typeString = new string[3]{"", ":", ""};

					for (int index2 = index + 1; index2 < nextIndex; index2++)
					{
						if (functionParts[index2].ToLower().Contains("name"))
							typeString[2] = functionParts[index2].Split('=')[1].Trim();

						if (functionParts[index2].ToLower().Contains("type"))
							typeString[0] = functionParts[index2].Split('=')[1].Trim();

						if (functionParts[index2].ToLower().Contains("value"))
							param.Value = functionParts[index2].Split('=')[1].Trim();

						if (functionParts[index2].ToLower().Contains("optional"))
							if (functionParts[index2].Split('=')[1].Equals(" y"))
								param.Optional = "True";

					}
					param.Type = typeString[0] + typeString[1] + typeString[2];
					flowLayoutPanelParameters.Controls.Add(new ParameterBox(param, _instanceVariables));
					//_instanceVariables.ParametersList.Add(new ParameterBox(param));
				}
			}
			UpdateParameterLists();
			RebuildParamaterPanel();
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
			UpdateParameterLists();
		}

		/// <summary>
		/// Updates the ParameterDef type and name lists from all parameters
		/// </summary>
		public void UpdateParameterLists()
		{
			_instanceVariables.UpdateParameterLists();
			comboBoxReturnTypeURL.Items.Clear();
			comboBoxReturnTypeURL.Items.AddRange(_instanceVariables.GetUrlObjectArray());
			comboBoxReturnTypeType.Items.Clear();
			comboBoxReturnTypeType.Items.AddRange(_instanceVariables.GetTypeObjectArray());
			comboBoxReturnTypeName.Items.Clear();
			comboBoxReturnTypeName.Items.AddRange(_instanceVariables.GetNameObjectArray());
			comboBoxReturnTypeValue.Items.Clear();
			comboBoxReturnTypeValue.Items.AddRange(_instanceVariables.GetValueObjectArray());
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
			if (_instanceVariables.FunctionExists(functionToAdd)) return;
			listboxFunctionList.Items.Add(functionToAdd.Name);
			_instanceVariables.AddFunction(functionToAdd);
		}

		/// <summary>
		/// Resets the entire form to the state of program start
		/// </summary>
		private void ClearEntireForm()
		{
			_instanceVariables = new Variables();
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
				var t = (TextBox)sender;
				if (String.IsNullOrEmpty(t.Text) || String.IsNullOrWhiteSpace(t.Text))
					buttonSaveCurrentChanges.Enabled = false;
				else
					buttonSaveCurrentChanges.Enabled = true;
			}

			private void buttonNewParameter_Click(object sender, EventArgs e)
			{
				flowLayoutPanelParameters.Controls.Add(new ParameterBox(_instanceVariables));
				RebuildParamaterPanel();
			}

			/// <summary>
			/// Toggles the fields in the return type group.
			/// </summary>
			private void checkBoxReturnType_CheckedChanged(object sender, EventArgs e)
			{
				var box = (CheckBox)sender;

				foreach (Control c in from Control c in box.Parent.Controls where c != box select c)
				{
					c.Enabled = c.Enabled != true;
				}
			}

			/// <summary>
			/// Save all the form data and add the function as a new function to the list box
			/// </summary>
			private void buttonSaveCurrentChanges_Click(object sender, EventArgs e)
			{
				if (_instanceVariables.FunctionExists(textBoxName.Text))
					SaveNewFunction();
				else
					if (Common.ConfirmUpdateFunction())
						UpdateCurrentFunction(); // Update existing function

				UpdateParameterLists();
			}

			/// <summary>
			/// Reverts changes to the state when the form was loaded
			/// If working at start, will produce a clean form
			/// If working on an existing function will revert to pre-edit
			/// </summary>
			private void buttonDiscardChanges_Click(object sender, EventArgs e)
			{
				if (Common.ConfirmDiscardChanges())
					if (_instanceVariables.IsBackupNull())
						PopulateFunctionForm(new FunctionDef());
					else
						PopulateFunctionForm(_instanceVariables.GetBackup());
			}

			/// <summary>
			/// Prompts to ensure the user wants to clear the form, then clears all form entry if yes
			/// </summary>
			private void buttonNewFunction_Click(object sender, EventArgs e)
			{
				if (convertWikiPagesToolStripMenuItem.Checked == true)
					WikiParser();
				else
				{
					if (Common.ConfirmClearForm())
						PopulateFunctionForm(new FunctionDef());
				}
				
			}

			private void buttonShowExamples_Click(object sender, EventArgs e)
			{
				if (_exampleWindowInstance == null || _exampleWindowInstance.IsDisposed)
				{
					_exampleWindowInstance = new ExamplesWindow();
					_exampleWindowInstance.SetInstanceVariable(ref _instanceVariables);
					_exampleWindowInstance.PopulateForm();
				}
				_exampleWindowInstance.Show();

				if (_exampleWindowInstance.Focused == false)
					_exampleWindowInstance.Focus();
			}

			private void flowLayoutPanelParameters_ControlAdded(object sender, ControlEventArgs e)
			{
				RebuildParamaterPanel();
			}

			private void flowLayoutPanelParameters_ControlRemoved(object sender, ControlEventArgs e)
			{
				RebuildParamaterPanel();
			}
		#endregion Events

		/// <summary>
		/// Takes a function and fills in all the window fields
		/// with their appropriate data
		/// </summary>
		public void PopulateFunctionForm(FunctionDef func)
		{
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

			// save the settings to a global first, so we can revert if a bad change is made
			_instanceVariables.SetBackup(func);
			_instanceVariables.SetExampleList(func.ExampleList);

			if (_exampleWindowInstance != null)
				_exampleWindowInstance.PopulateForm();

			textBoxName.Text = func.Name;
			textBoxAlias.Text = func.Alias;
			textBoxVersion.Text = func.Version;
			textBoxOrigin.Text = func.FromPlugin;
			textBoxCategory.Text = func.Category;

			if (func.Tags != null)
				foreach (string s in func.Tags) 
					textBoxTags.Text += s + System.Environment.NewLine;

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
					comboBoxReturnTypeValue.Text = "";
					checkBoxReturnType.Checked = false;
					break;
				default:
					comboBoxReturnTypeURL.Text = func.ReturnType[0].Type;
					var s = func.ReturnType[0].Type.Split(':');
					if (s.Length >= 1) { comboBoxReturnTypeType.Text = s[0]; }
					if (s.Length >= 2) { comboBoxReturnTypeName.Text = s[1]; }
					comboBoxReturnTypeValue.Text = func.ReturnType[0].Value;
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
						Control c = new ParameterBox(parameter, _instanceVariables);

						//Variables.ParametersList.Add(c);
						flowLayoutPanelParameters.Controls.Add(c);
					}
					RebuildParamaterPanel();
				}
			}

		/// <summary>
		/// Renumbers the groupbox text on all groupboxes in the ParameterDef list
		/// </summary>
		public void RebuildParamaterPanel()
		{
			for (int i = 0; i < flowLayoutPanelParameters.Controls.Count; i++)
				flowLayoutPanelParameters.Controls[i].Text = "ParameterBox " + (i + 1).ToString();
		}

		/// <summary>
		/// Converts the window data into a function object
		/// </summary>
		/// <param name="function">A function that will be returned filled with the data in the window.</param>
		private FunctionDef WindowToFunction(FunctionDef function)
		{
			// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
		// NAME
			if (!String.IsNullOrEmpty(textBoxName.Text))
				function.Name = textBoxName.Text;

		// ALIAS
			if (String.IsNullOrEmpty(textBoxAlias.Text))
				function.Alias = null;
			else
				function.Alias = textBoxAlias.Text;

		// VERSION 
			if (String.IsNullOrEmpty(textBoxVersion.Text))
				function.Version = null;
			else
				function.Version = textBoxVersion.Text;

		// ORIGIN
			if (String.IsNullOrEmpty(textBoxOrigin.Text))
				function.FromPlugin = null;
			else
				function.FromPlugin = textBoxOrigin.Text;

		// CATEGORY
			if (String.IsNullOrEmpty(textBoxCategory.Text))
				function.Category = null;
			else
				function.Category = textBoxCategory.Text;
			// ReSharper restore ConvertIfStatementToConditionalTernaryExpression

		// TAGS
			if (!String.IsNullOrEmpty(textBoxTags.Text))
			{
				// if the tag variable is null, and there are tags to put in it, create a new list
				if (function.Tags == null)
					function.Tags = new List<string>();

				// step through each line in the text box, each line is a tag, and store each one
				// in the list. If there is an empty line, or the line exists already, skip it.
				foreach (var line in textBoxTags.Lines.Where(line => function.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line)))
				{
					function.Tags.Add(line);
				}
			}

		// CALLING CONVENTION
			if (radioButtonCallingConventionBase.Checked == true) 
				function.Convention = "B";
			else if (radioButtonCallingConventionEither.Checked == true)
				function.Convention = "E";
			else if (radioButtonCallingConventionRef.Checked == true)
				function.Convention = "R";


			// TODO: Update javascript to handle true/false
			switch (checkBoxConditional.Checked)
			{
				case true:
					function.Condition = checkBoxConditional.Checked.ToString();
					break;
				default:
					function.Condition = null;
					break;
			}

		// PARAMETERS
			if (flowLayoutPanelParameters.Controls.Count > 0)
			{
				if (function.Parameters == null)
					function.Parameters = new List<ParameterDef>();

				function.Parameters.Clear();

				// ReSharper disable PossibleInvalidCastExceptionInForeachLoop
				foreach (ParameterBox c in Variables.ParametersList)
					function.Parameters.Add(c.ToParameterDef());
			}
			else { function.Parameters = null; }
				// ReSharper restore PossibleInvalidCastExceptionInForeachLoop

		// RETURN TYPE
			if (checkBoxReturnType.Checked)
			{
				if (function.ReturnType == null)
				{
					function.ReturnType = new List<ReturnTypeDef>(); 
					function.ReturnType.Add(new ReturnTypeDef());
				}

				if (!String.IsNullOrEmpty(comboBoxReturnTypeURL.Text)) 
					function.ReturnType[0].Type = comboBoxReturnTypeURL.Text;

				var s = comboBoxReturnTypeType.Text + ":" + comboBoxReturnTypeName.Text;
				if (!String.IsNullOrEmpty(s))
					function.ReturnType[0].Type = s;
			}

		// EXAMPLES
			if (!_instanceVariables.IsExampleListNull())
				function.ExampleList = _instanceVariables.GetExampleList();

		// DESCRIPTION
			if (!String.IsNullOrEmpty(richTextBoxDescription.Text))
			{
				if (function.Description == null) 
					function.Description = new List<string>();

				function.Description.Clear();
				foreach (var line in richTextBoxDescription.Lines)
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
			var func = WindowToFunction(new FunctionDef());
			AddToFunctionListBox(func);
		}

		/// <summary>
		/// Finds the current function by name and replaces its data with that in the window
		/// </summary>
		private void UpdateCurrentFunction()
		{
			WindowToFunction(_instanceVariables.GetFunctionList().Find(f => f.Name == textBoxName.Text));
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
					if (Common.ConfirmDelete("function(s)"))
					{
						_instanceVariables.RemoveFunction(listboxFunctionList.SelectedItems);
						for (int i = listboxFunctionList.SelectedItems.Count - 1; i >= 0; i--)
							listboxFunctionList.Items.Remove(listboxFunctionList.SelectedItems[i]);
					}
				}
			}

			/// <summary>
			/// Bulk change the category of all selected functions.
			/// </summary>
			private void buttonListBoxChangeCategory_Click(object sender, EventArgs e)
			{
				string input = "";
				bool d = Common.InputBox("Change Category", "Enter the new Category", ref input);

				// decided to bulk change category on selected functions
				if (d)
					_instanceVariables.UpdateCategoryField(listboxFunctionList.SelectedItems, input);
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
				PopulateFunctionForm(_instanceVariables.GetFunctionByName(listboxFunctionList.SelectedItem.ToString()));
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

					_instanceVariables.CleanFunctionList();
					sw.Write(JsonConvert.SerializeObject(_instanceVariables.GetFunctionList(), settings));
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
			if (Common.ConfirmCloseForm())
				Application.Exit();
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

	#endregion Events

		

	}
}
