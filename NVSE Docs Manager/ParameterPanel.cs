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

using System.Reflection;

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
			Control parent = (sender as System.Windows.Forms.Button).Parent;
			flowLayoutPanelParameters.Controls.Remove(parent);
			parametersList.Remove(parent);
			rebuildParamaterPanel();
		}

		/// <summary>
		/// Creates a new ParameterDef groupbox
		/// </summary>
		/// <returns>Returns a groupbox populated with ParameterDef list form controls.</returns>
		private Control createNewParameter()
		{
			Control newParam = buildNewParameterForm();
			return newParam;
		}

		/// <summary>
		/// Renumbers the groupbox text on all groupboxes in the ParameterDef list
		/// </summary>
		private void rebuildParamaterPanel()
		{
			for (int i = 0; i < parametersList.Count(); i++)
			{
				parametersList[i].Text = "ParameterDef " + (i + 1).ToString();
			}
		}

		/// <summary>
		/// Creates a ParameterDef list and populates all the groupboxes with
		/// the values from a function's parameters
		/// </summary>
		/// <param name="paramList">List of parameters</param>
		private void populateParameterList(List<ParameterDef> paramList)
		{
			if (paramList != null)
			{
				foreach (ParameterDef param in paramList)
				{
					System.Windows.Forms.GroupBox newParameter = (System.Windows.Forms.GroupBox)createNewParameter();

					System.Windows.Forms.ComboBox cBox;
					System.Windows.Forms.CheckBox cBox2;

					if (!String.IsNullOrEmpty(param.url))
					{
						cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxURL"];
						cBox.SelectedIndex = parameterURLList.IndexOf(param.url.ToString());
					}

					string[] s = param.type.Split(':');
					if (s.Length >= 1)
					{
						cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxType"];
						cBox.Text = s[0];
					}
					if (s.Length >= 2)
					{
						cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxName"];
						cBox.Text = s[1];
					}

					if (!String.IsNullOrEmpty(param.optional))
					{
						cBox2 = (System.Windows.Forms.CheckBox)newParameter.Controls["checkBoxOptional"];
						cBox2.Checked = true;
					}
					parametersList.Add(newParameter);
					flowLayoutPanelParameters.Controls.Add(newParameter);
				}
			}
		}

		/// <summary>
		/// Builds a ParameterDef panel form
		/// </summary>
		/// <returns>Returns a ParameterDef groupbox with all forms</returns>
		private Control buildNewParameterForm()
		{
			// create a new group box for the new ParameterDef
				System.Windows.Forms.GroupBox newParameter = new System.Windows.Forms.GroupBox();
				newParameter.Size = new System.Drawing.Size(523, 60);
				newParameter.Text = "Parameter " + (parametersList.Count() + 1).ToString();

			// create the remove button
				System.Windows.Forms.Button removeButton = new System.Windows.Forms.Button();
				removeButton.Click += new System.EventHandler(this.removeParameter_Click);
				removeButton.Text = "X";
				removeButton.Location = new System.Drawing.Point(6, 16);
				removeButton.Size = new System.Drawing.Size(23, 37);
				newParameter.Controls.Add(removeButton);


			// URL
			// create the URL label and add it to the group box
				System.Windows.Forms.Label urlLabel = new System.Windows.Forms.Label();
				urlLabel.Text = "URL:";
				urlLabel.Location = new System.Drawing.Point(33, 16);
				urlLabel.AutoSize = true;
				newParameter.Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
				System.Windows.Forms.ComboBox urlCombobox = new System.Windows.Forms.ComboBox();
				urlCombobox.Name = "comboBoxURL";
				urlCombobox.Items.AddRange(parameterURLList.ToArray());
				urlCombobox.Sorted = true;
				urlCombobox.Location = new System.Drawing.Point(36, 32);
				urlCombobox.Size = new System.Drawing.Size(140, 21);
				urlCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
				newParameter.Controls.Add(urlCombobox);

			// Type
			// create the Type label and add it to the group box
				System.Windows.Forms.Label typeLabel = new System.Windows.Forms.Label();
				typeLabel.Text = "Type:";
				typeLabel.Location = new System.Drawing.Point(179, 16);
				typeLabel.AutoSize = true;
				newParameter.Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
				System.Windows.Forms.ComboBox typeCombobox = new System.Windows.Forms.ComboBox();
				typeCombobox.Name = "comboBoxType";
				typeCombobox.Items.AddRange(parameterTypesList.ToArray());
				typeCombobox.Sorted = true;
				typeCombobox.Location = new System.Drawing.Point(182, 32);
				typeCombobox.Size = new System.Drawing.Size(140, 21);
				newParameter.Controls.Add(typeCombobox);

			// Name
			// create the Type label and add it to the group box
				System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label();
				nameLabel.Text = "Name:";
				nameLabel.Location = new System.Drawing.Point(325, 16);
				nameLabel.AutoSize = true;
				newParameter.Controls.Add(nameLabel);
			// create the Type combobox and add it to the group box
				System.Windows.Forms.ComboBox nameCombobox = new System.Windows.Forms.ComboBox();
				nameCombobox.Name = "comboBoxName";
				nameCombobox.Items.AddRange(parameterNamesList.ToArray());
				nameCombobox.Sorted = true;
				nameCombobox.Location = new System.Drawing.Point(328, 32);
				nameCombobox.Size = new System.Drawing.Size(140, 21);
				newParameter.Controls.Add(nameCombobox);

			// Optional
				System.Windows.Forms.CheckBox optionalCheckbox = new System.Windows.Forms.CheckBox();
				optionalCheckbox.Name = "checkBoxOptional";
				optionalCheckbox.Text = "Optional";
				optionalCheckbox.Location = new System.Drawing.Point(471, 15);
				optionalCheckbox.AutoSize = true;
				optionalCheckbox.CheckAlign = ContentAlignment.BottomCenter;
				optionalCheckbox.TextAlign = ContentAlignment.TopCenter;
				newParameter.Controls.Add(optionalCheckbox);

			return newParameter;
		}		

	}
}
