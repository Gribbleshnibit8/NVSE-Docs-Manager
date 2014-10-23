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

		private void buttonNewParameter_Click(object sender, EventArgs e)
		{
			Control newParam = createNewParameter();
			parametersList.Add(newParam);
			flowLayoutPanelParameters.Controls.Add(newParam);
		}

		private void buttonCopyParameter_Click(object sender, EventArgs e)
		{
			Control toCopy = parametersList.Last();
			Control newParam = createNewParameter();

			System.Windows.Forms.ComboBox oldBox, newBox;

			// URL Box values
			oldBox = (System.Windows.Forms.ComboBox)toCopy.Controls["comboBoxURL"];
			newBox = (System.Windows.Forms.ComboBox)newParam.Controls["comboBoxURL"];
			newBox.SelectedIndex = oldBox.SelectedIndex;

			// Type Box values
			oldBox = (System.Windows.Forms.ComboBox)toCopy.Controls["comboBoxType"];
			newBox = (System.Windows.Forms.ComboBox)newParam.Controls["comboBoxType"];
			newBox.Text = oldBox.Text;

			// Type Box values
			oldBox = (System.Windows.Forms.ComboBox)toCopy.Controls["comboBoxOptional"];
			newBox = (System.Windows.Forms.ComboBox)newParam.Controls["comboBoxOptional"];
			newBox.SelectedIndex = oldBox.SelectedIndex;


			parametersList.Add(newParam);
			flowLayoutPanelParameters.Controls.Add(newParam);
			rebuildParamaterPanel();
		}

		private void removeParameter_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
			Control parent = clickedButton.Parent;

			flowLayoutPanelParameters.Controls.Remove(parent);
			parametersList.Remove(parent);
			rebuildParamaterPanel();
		}

		private Control createNewParameter()
		{
			Control newParam = buildNewParameterForm();
			return newParam;
		}

		private void rebuildParamaterPanel()
		{
			for (int i = 0; i < parametersList.Count(); i++)
			{
				parametersList[i].Text = "Parameter " + (i + 1).ToString();
			}
		}

		// Populates the parameter panel from a loaded function
		private void populateParameterList(List<Parameter> paramList)
		{
			foreach (Parameter param in paramList)
			{
				System.Windows.Forms.GroupBox newParameter = (System.Windows.Forms.GroupBox)createNewParameter();

				System.Windows.Forms.ComboBox cBox;
				System.Windows.Forms.CheckBox cBox2;

				if (!String.IsNullOrEmpty(param.url))
				{
					cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxURL"];
					cBox.SelectedIndex = parameterURLList.IndexOf(param.url.ToString());
				}
				
				cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxType"];
				cBox.Text = param.type;

				if (!String.IsNullOrEmpty(param.optional))
				{
					cBox2 = (System.Windows.Forms.CheckBox)newParameter.Controls["checkBoxOptional"];
					cBox2.Checked = true;
				}

				parametersList.Add(newParameter);
				flowLayoutPanelParameters.Controls.Add(newParameter);
			}
		}

		// creates a new parameter groupbox with contents, sets and registers the buttons
		private Control buildNewParameterForm()
		{
			// create a new group box for the new parameter
			System.Windows.Forms.GroupBox newParameter = new System.Windows.Forms.GroupBox();
			newParameter.Size = new System.Drawing.Size(525, 55);
			newParameter.Text = "Parameter " + (parametersList.Count() + 1).ToString();

			// create the remove button
			System.Windows.Forms.Button removeButton = new System.Windows.Forms.Button();
			removeButton.Click += new System.EventHandler(this.removeParameter_Click);
			removeButton.Text = "X";
			removeButton.Location = new System.Drawing.Point(6, 19);
			removeButton.AutoSize = true;
			removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			newParameter.Controls.Add(removeButton);


			// URL
			// create the URL label and add it to the group box
			System.Windows.Forms.Label urlLabel = new System.Windows.Forms.Label();
			urlLabel.Text = "URL";
			urlLabel.Location = new System.Drawing.Point(36, 24);
			urlLabel.AutoSize = true;
			newParameter.Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
			System.Windows.Forms.ComboBox urlCombobox = new System.Windows.Forms.ComboBox();
			urlCombobox.Name = "comboBoxURL";
			urlCombobox.Items.AddRange(parameterURLList.ToArray());
			urlCombobox.Location = new System.Drawing.Point(71, 20);
			urlCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
			newParameter.Controls.Add(urlCombobox);

			// Type
			// create the Type label and add it to the group box
			System.Windows.Forms.Label typeLabel = new System.Windows.Forms.Label();
			typeLabel.Text = "Type";
			typeLabel.Location = new System.Drawing.Point(198, 24);
			typeLabel.AutoSize = true;
			newParameter.Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
			System.Windows.Forms.ComboBox typeCombobox = new System.Windows.Forms.ComboBox();
			typeCombobox.Name = "comboBoxType";
			//typeCombobox.Items.AddRange();
			typeCombobox.Location = new System.Drawing.Point(233, 20);
			typeCombobox.Size = new System.Drawing.Size(137, 21);
			newParameter.Controls.Add(typeCombobox);

			// Optional
			System.Windows.Forms.CheckBox optionalCheckbox = new System.Windows.Forms.CheckBox();
			optionalCheckbox.Name = "checkBoxOptional";
			optionalCheckbox.Text = "Optional";
			optionalCheckbox.Location = new System.Drawing.Point(454, 22);
			optionalCheckbox.AutoSize = true;
			optionalCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			newParameter.Controls.Add(optionalCheckbox);

			return newParameter;
		}		

	}
}
