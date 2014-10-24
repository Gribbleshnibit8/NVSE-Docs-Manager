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
	public partial class MainWindow
	{

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
		#endregion

		#region Tool Strip Handlers

		string fileName;

		private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
			openFileDialog1.Multiselect = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
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
				sw.Write(JsonConvert.SerializeObject(LoadedFunctionsList, Formatting.Indented));
				sw.Close();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (confirmCloseForm() == DialogResult.Yes)
				System.Windows.Forms.Application.Exit();
		}
		#endregion

		#region Function Panel Events

		/// <summary>
		/// Save all the form data and add the function as a new function to the list box
		/// </summary>
		private void buttonSaveCurrentChanges_Click(object sender, EventArgs e)
		{
			if (!LoadedFunctionsList.Exists(f => f.Name == textBoxName.Text)) { saveNewFunction(); }
			else
			{
				// Update existing function
				DialogResult d = MessageBox.Show("This function already exists. Would you like to update it with the new information?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (d == DialogResult.Yes)
					updateCurrentFunction(); // Update existing function
			} // end else
		} // end buttonSaveCurrentChanges_Click
		
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

		/// <summary>
		/// Prompts to ensure the user wants to clear the form, then clears all form entry if yes
		/// </summary>
		private void buttonNewFunction_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Are you sure you want to clear the form?", "New Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d == DialogResult.Yes)
				populateFunctionForm(new FunctionDef());
		}

		#endregion

		#region Function List Events

		/// <summary>
		/// Uses MouseUp event to catch when the selcted count changes.
		/// Checks how many are selected and enables the editing buttons.
		/// </summary>
		private void listboxFunctionList_MouseUp(object sender, MouseEventArgs e)
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

		/// <summary>
		/// On double click a name in the list box, load the function data into the fields
		/// </summary>
		private void listboxFunctionList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				//LoadedFunctionsList.Find(f => f.Name == treeView1.SelectedNode.Text)
				populateFunctionForm(LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItem.ToString()));
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
		} // end buttonListBoxDeleteItem_Click

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
		} // end buttonListBoxChangeCategory_Click

		#endregion Function List Events


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

		

	}
}
