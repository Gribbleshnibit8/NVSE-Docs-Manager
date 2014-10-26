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
	public class Parameter : GroupBox
	{

		Control panel;
		public string Url { get; set; }
		public string Type { get; set; }
		public string[] urlBoxContents { get; set; }
		public string[] typeBoxContents { get; set; }
		public string[] nameBoxContents { get; set; }

		/// <summary>
		/// Shows the numerical position of this control in a list
		/// </summary>
		public int Position { get; set; }
		public bool Optional { get; set; }

		public Parameter()
		{
			Url = "";
			Type = ":";
			Optional = false;
			urlBoxContents = new string[1] { "" };
			typeBoxContents = new string[1] { "" };
			nameBoxContents = new string[1] { "" };
			panel = buildNewParameterForm();
		}

		/// <summary>
		/// Represents a groupbox of default controls consistent with the Parameter data type
		/// </summary>
		/// <param name="urlBoxArray">A list of url hash strings</param>
		/// <param name="typeBoxArray">A list of all values that can be of type type (Ex. integer, boolean, string)</param>
		/// <param name="nameBoxArray">A list of all values that can be a name</param>
		public Parameter(string[] urlArray, string[] typeArray, string[] nameArray)
		{
			Url = "";
			Type = ":";
			Optional = false;
			urlBoxContents = urlArray;
			typeBoxContents = typeArray;
			nameBoxContents = nameArray;
			panel = buildNewParameterForm();
		}

		/// <summary>
		/// Represents a groupbox of default controls consistent with the Parameter data type
		/// </summary>
		/// <param name="url">The page hash with information of this data type</param>
		/// <param name="type">The data represented by this parameter</param>
		/// <param name="optional">Is an optional parameter</param>
		/// <param name="urlBoxArray">A list of url hash strings</param>
		/// <param name="typeBoxArray">A list of all values that can be of type type (Ex. integer, boolean, string)</param>
		/// <param name="nameBoxArray">A list of all values that can be a name</param>
		public Parameter(string url, string type, bool optional, string[] urlArray, string[] typeArray, string[] nameArray)
		{
			Url = url;
			Type = type;
			Optional = optional;
			urlBoxContents = urlArray;
			typeBoxContents = typeArray;
			nameBoxContents = nameArray;
			panel = buildNewParameterForm();
		}

		public Parameter(Parameter toCopy)
		{
			Url = toCopy.Url;
			Type = toCopy.Type;
			Optional = toCopy.Optional;
			urlBoxContents = toCopy.urlBoxContents;
			typeBoxContents = toCopy.typeBoxContents;
			nameBoxContents = toCopy.nameBoxContents;
			panel = buildNewParameterForm();
		}

		public override string ToString()
		{
			string s = "URL: " + Url + Environment.NewLine + "Type: " + Type + Environment.NewLine + "Optional: " + Optional.ToString();
			return s;
		}

		private string getTypeType(string type)
		{
			string[] s = type.Split(':');
			if (s.Length >= 1)
				return s[0];
			return "";
		}

		private string getTypeName(string type)
		{
			string[] s = type.Split(':');
			if (s.Length >= 2)
				return s[1];
			return "";
		}

		private void removeParameter_Click(object sender, System.EventArgs e)
		{
			Control parent = (sender as System.Windows.Forms.Button).Parent;
			Control grandparent = (parent as System.Windows.Forms.GroupBox).Parent;
			grandparent.Controls.Remove(parent);
			//rebuildParamaterPanel();
		}

		private void urlBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Url = ((System.Windows.Forms.ComboBox)sender).Text;
		}

		private void typeBox_KeyUp(object sender, EventArgs e)
		{
			string s = ((System.Windows.Forms.ComboBox)sender).Text;
			string[] t = Type.Split(':');
			t[0] = s;
			if (t.Length == 1)
				Type = t[0] + ":";
			else
				Type = t[0] + ":" + t[1];
		}

		private void nameBox_KeyUp(object sender, EventArgs e)
		{
			string s = ((System.Windows.Forms.ComboBox)sender).Text;
			string[] t = Type.Split(':');
			t[1] = s;
			if (String.IsNullOrEmpty(t[0]))
				Type = ":" + t[1];
			else
				Type = t[0] + ":" + t[1];
		}

		private void optionalBox_CheckedChanged(object sender, EventArgs e)
		{
			Optional = ((System.Windows.Forms.CheckBox)sender).Checked;
		}

		/// <summary>
		/// Builds a ParameterDef panel form
		/// </summary>
		/// <returns>Returns a ParameterDef groupbox with all forms</returns>
		private Control buildNewParameterForm()
		{
			// create a new group box for the new ParameterDef
			this.Size = new System.Drawing.Size(523, 60);
			this.Text = "Parameter " + Position.ToString();

			// create the remove button
			System.Windows.Forms.Button removeButton = new System.Windows.Forms.Button();
			removeButton.Click += new System.EventHandler(this.removeParameter_Click);
			removeButton.Text = "X";
			removeButton.Location = new System.Drawing.Point(6, 16);
			removeButton.Size = new System.Drawing.Size(23, 37);
			this.Controls.Add(removeButton);


			// URL
			// create the URL label and add it to the group box
			System.Windows.Forms.Label urlLabel = new System.Windows.Forms.Label();
			urlLabel.Text = "URL:";
			urlLabel.Location = new System.Drawing.Point(33, 16);
			urlLabel.AutoSize = true;
			this.Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
			System.Windows.Forms.ComboBox urlCombobox = new System.Windows.Forms.ComboBox();
			urlCombobox.SelectedIndexChanged += new EventHandler(this.urlBox_SelectedIndexChanged);
			urlCombobox.Name = "comboBoxURL";
			urlCombobox.Items.AddRange(urlBoxContents);
			urlCombobox.Sorted = true;
			urlCombobox.Location = new System.Drawing.Point(36, 32);
			urlCombobox.Size = new System.Drawing.Size(140, 21);
			urlCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
			urlCombobox.Text = Url;
			this.Controls.Add(urlCombobox);

			// Type
			// create the Type label and add it to the group box
			System.Windows.Forms.Label typeLabel = new System.Windows.Forms.Label();
			typeLabel.Text = "Type:";
			typeLabel.Location = new System.Drawing.Point(179, 16);
			typeLabel.AutoSize = true;
			this.Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
			System.Windows.Forms.ComboBox typeCombobox = new System.Windows.Forms.ComboBox();
			typeCombobox.KeyUp += new KeyEventHandler(this.typeBox_KeyUp);
			typeCombobox.Name = "comboBoxType";
			typeCombobox.Items.AddRange(typeBoxContents);
			typeCombobox.Sorted = true;
			typeCombobox.Location = new System.Drawing.Point(182, 32);
			typeCombobox.Size = new System.Drawing.Size(140, 21);
			typeCombobox.Text = getTypeType(Type);
			this.Controls.Add(typeCombobox);

			// Name
			// create the Type label and add it to the group box
			System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label();
			nameLabel.Text = "Name:";
			nameLabel.Location = new System.Drawing.Point(325, 16);
			nameLabel.AutoSize = true;
			this.Controls.Add(nameLabel);
			// create the Type combobox and add it to the group box
			System.Windows.Forms.ComboBox nameCombobox = new System.Windows.Forms.ComboBox();
			nameCombobox.KeyUp += new KeyEventHandler(this.nameBox_KeyUp);
			nameCombobox.Name = "comboBoxName";
			nameCombobox.Items.AddRange(nameBoxContents);
			nameCombobox.Sorted = true;
			nameCombobox.Location = new System.Drawing.Point(328, 32);
			nameCombobox.Size = new System.Drawing.Size(140, 21);
			nameCombobox.Text = getTypeName(Type);
			this.Controls.Add(nameCombobox);

			// Optional
			System.Windows.Forms.CheckBox optionalCheckbox = new System.Windows.Forms.CheckBox();
			optionalCheckbox.CheckedChanged += new EventHandler(this.optionalBox_CheckedChanged);
			optionalCheckbox.Name = "checkBoxOptional";
			optionalCheckbox.Text = "Optional";
			optionalCheckbox.Location = new System.Drawing.Point(471, 15);
			optionalCheckbox.AutoSize = true;
			optionalCheckbox.CheckAlign = ContentAlignment.BottomCenter;
			optionalCheckbox.TextAlign = ContentAlignment.TopCenter;
			optionalCheckbox.Checked = Optional;
			this.Controls.Add(optionalCheckbox);

			return this;
		}

	}






	public partial class MainWindow : Form
	{
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
					Control c = new Parameter(parameter.url, 
						parameter.type, 
						parameter.optional.Equals("True"), 
						parameterURLList.ToArray(), 
						parameterTypesList.ToArray(), 
						parameterNamesList.ToArray());

					parametersList.Add(c);
					flowLayoutPanelParameters.Controls.Add(c);
					rebuildParamaterPanel();
				}
			}
			//if (paramList != null)
			//{
			//	foreach (ParameterDef param in paramList)
			//	{
			//		System.Windows.Forms.GroupBox newParameter = (System.Windows.Forms.GroupBox)createNewParameter();

			//		System.Windows.Forms.ComboBox cBox;
			//		System.Windows.Forms.CheckBox cBox2;

			//		if (!String.IsNullOrEmpty(param.url))
			//		{
			//			cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxURL"];
			//			cBox.SelectedIndex = parameterURLList.IndexOf(param.url.ToString());
			//		}

			//		string[] s = param.type.Split(':');
			//		if (s.Length >= 1)
			//		{
			//			cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxType"];
			//			cBox.Text = s[0];
			//		}
			//		if (s.Length >= 2)
			//		{
			//			cBox = (System.Windows.Forms.ComboBox)newParameter.Controls["comboBoxName"];
			//			cBox.Text = s[1];
			//		}

			//		if (!String.IsNullOrEmpty(param.optional))
			//		{
			//			cBox2 = (System.Windows.Forms.CheckBox)newParameter.Controls["checkBoxOptional"];
			//			cBox2.Checked = true;
			//		}
			//		parametersList.Add(newParameter);
			//		flowLayoutPanelParameters.Controls.Add(newParameter);
			//	}
			//}
		}


	}
}
