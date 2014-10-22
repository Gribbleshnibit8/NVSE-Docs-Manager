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

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{

	// Mouse event handlers
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

			else if (sender == radioButtonConditionalTrue)
				s = "If this function can be used as a conditional in the condition dialog";

			else if (sender == radioButtonConditionalFalse)
				s = "If this function cannot be used as a conditional in the condition dialog";

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
			flowLayoutPanelParameters.Focus();
		}

		// Save all the form data and add the function as a new function to the list box
		// TODO: Check if function exists and update instead of create new
		private void buttonSaveCurrentChanges_Click(object sender, EventArgs e)
		{
			foreach (FunctionDef f in functionsList)
			{
				if (f.Name == textBoxName.Text)
				{
					// Update existing function
					break;
				}
				else
				{
					// save new function
					break;
				}
					
			}


			FunctionDef func = new FunctionDef();

			func.Name = textBoxName.Text;
			func.Alias = textBoxAlias.Text;
			func.Version = textBoxVersion.Text;
			func.FromPlugin = textBoxOrigin.Text;
			func.Category = textBoxCategory.Text;

			if (textBoxTags.Text != "")
				func.Tags.AddRange(textBoxTags.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));


			if (radioButtonCallingConventionBase.Checked == true)
				func.Convention = "B";
			else if (radioButtonCallingConventionEither.Checked == true)
				func.Convention = "E";
			else if (radioButtonCallingConventionRef.Checked == true)
				func.Convention = "R";

			// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
			if (radioButtonConditionalFalse.Checked == true)
				func.Condition = "No";
			else
				func.Condition = "Yes";

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

				func.Parameters.Add(newParam);
			}

			functionsList.Add(func);
			listboxFunctionList.Items.Add(func.Name);

		}

		// On double click a name in the list box, load the function data into the fields
		private void listboxFunctionList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				flowLayoutPanelParameters.Controls.Clear();
				parametersList.Clear();

				MessageBox.Show(listboxFunctionList.SelectedItem.ToString());

				FunctionDef func = functionsList.ElementAt(listboxFunctionList.SelectedIndex);

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
				if (func.Condition == "No")
					radioButtonConditionalFalse.Checked = true;
				else
					radioButtonConditionalTrue.Checked = true;

				populateParameterList(func.Parameters);

				//functionsList.Add(func);
				//listboxFunctionList.Items.Add(func.Name);

			}
		}

		// toggles the fields in the return type group
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
	}
}
