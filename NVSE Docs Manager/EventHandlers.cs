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
			//if (LoadedFunctionsList.Count == 0)
			//	saveNewFunction();
			//else
			//{
				if (!LoadedFunctionsList.Exists(f => f.Name == textBoxName.Text)) { saveNewFunction(); }
				else
				{
					// Update existing function
					DialogResult d = MessageBox.Show("This function already exists. Would you like to update it with the new information?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (d == DialogResult.Yes)
						updateCurrentFunction(); // Update existing function
				} // end else
		} // end buttonSaveCurrentChages

		// On double click a name in the list box, load the function data into the fields
		private void listboxFunctionList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				//LoadedFunctionsList.Find(f => f.Name == treeView1.SelectedNode.Text)
				populateFunctionForm(LoadedFunctionsList.Find(f => f.Name == listboxFunctionList.SelectedItem.ToString()));
			}
		}

		// toggles the fields in the return type group
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

		// Reverts changes to the state when the form was loaded
		// If working at start, will produce a clean form
		// If working on an existing function will revert to pre-edit
		private void buttonDiscardChanges_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Are you sure you want to discard the changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d == DialogResult.Yes)
				populateFunctionForm(currentEdittingBackup);
		}

		// Ensures that the function has a name before allowing it to be saved
		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)sender;
			if (String.IsNullOrEmpty(t.Text) || String.IsNullOrWhiteSpace(t.Text))
				buttonSaveCurrentChanges.Enabled = false;
			else
				buttonSaveCurrentChanges.Enabled = true;
		}
	}
}
