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

		private void buttonParametersNew_Click(object sender, EventArgs e)
		{
			Control newParam = createNewParameter();
			parametersList.Add(newParam);
			flowLayoutPanelParameters.Controls.Add(newParam);
		}

		private void buttonParameterCopy_Click(object sender, EventArgs e)
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

		private Control createNewParameterForm(string title, bool hasOptional)
		{
			// create a new group box for the new parameter
			System.Windows.Forms.GroupBox newParameter = new System.Windows.Forms.GroupBox();
			newParameter.Size = new System.Drawing.Size(519, 61);
			newParameter.Text = title + " " + (parametersList.Count() + 1).ToString();

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
			urlCombobox.Items.AddRange(paramaterURLs);
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
			if (hasOptional)
			{
				// create the Optional label and add it to the group box
				System.Windows.Forms.Label optionalLabel = new System.Windows.Forms.Label();
				optionalLabel.Text = "URL";
				optionalLabel.Location = new System.Drawing.Point(376, 24);
				optionalLabel.AutoSize = true;
				newParameter.Controls.Add(optionalLabel);
				// create the Optional combobox and add it to the group box
				System.Windows.Forms.ComboBox optionalCombobox = new System.Windows.Forms.ComboBox();
				optionalCombobox.Name = "comboBoxOptional";
				optionalCombobox.Items.AddRange(new object[] { "True", "False" });
				optionalCombobox.Location = new System.Drawing.Point(428, 20);
				optionalCombobox.Size = new System.Drawing.Size(85, 21);
				optionalCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
				optionalCombobox.SelectedIndex = 1;
				newParameter.Controls.Add(optionalCombobox);
			}
			return newParameter;
		}

		private void rebuildParamaterPanel()
		{
			for (int i = 0; i < parametersList.Count(); i++)
			{
				parametersList[i].Text = "Parameter " + (i + 1).ToString();
			}
		}

		private Control createNewParameter()
		{
			Control newParam = createNewParameterForm("Parameter", true);
			return newParam;
		}

		private Control createNewReturnType()
		{
			Control newParam = createNewParameterForm("Return Type", false);
			return newParam;
		}

		void removeParameter_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
			Control parent = clickedButton.Parent;
			parent.Visible = false;
			parametersList.Remove(parent);
			rebuildParamaterPanel();
		}
	}
}
