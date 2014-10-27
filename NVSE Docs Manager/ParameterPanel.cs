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
		public string Optional { get; set; }
		public string[] urlBoxContents { get; set; }
		public string[] typeBoxContents { get; set; }
		public string[] nameBoxContents { get; set; }

		#region Constructors
		public Parameter()
		{
			Url = "";
			Type = ":";
			Optional = "False";
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
			Optional = "False";
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
		public Parameter(string url, string type, string optional, string[] urlArray, string[] typeArray, string[] nameArray)
		{
			Url = url;
			Type = type;
			Optional = optional;
			urlBoxContents = urlArray;
			typeBoxContents = typeArray;
			nameBoxContents = nameArray;
			panel = buildNewParameterForm();
		}

		/// <summary>
		/// Copies one Parameter to a new one
		/// </summary>
		/// <param name="toCopy">Parameter Control to be copied</param>
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
		#endregion

		#region Getters/Setters
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

		private string setTypeType(string type)
		{
			string[] t = Type.Split(':');
			t[0] = type;
			if (t.Length == 1)
				return t[0] + ":";
			else
				return t[0] + ":" + t[1];
		}

		private string setTypeName(string type)
		{
			string[] t = Type.Split(':');
			t[1] = type;
			if (String.IsNullOrEmpty(t[0]))
				return ":" + t[1];
			else
				return t[0] + ":" + t[1];
		}
		#endregion

		#region Event Handlers
		private void removeParameter_Click(object sender, System.EventArgs e)
		{
			Control parent = (sender as System.Windows.Forms.Button).Parent;
			Control grandparent = (parent as System.Windows.Forms.GroupBox).Parent;
			grandparent.Controls.Remove(parent);
			for (int i = 0; i < grandparent.Controls.Count; i++)
			{
				grandparent.Controls[i].Text = "Parameter " + (i + 1).ToString();
			}
		}

		private void urlBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Url = ((System.Windows.Forms.ComboBox)sender).Text;
		}

		private void typeBox_KeyUp(object sender, EventArgs e)
		{
			string s = ((System.Windows.Forms.ComboBox)sender).Text;
			Type = setTypeType(s);
		}

		private void nameBox_KeyUp(object sender, EventArgs e)
		{
			string s = ((System.Windows.Forms.ComboBox)sender).Text;
			Type = setTypeName(s);
		}

		private void optionalBox_CheckedChanged(object sender, EventArgs e)
		{
			Optional = ((System.Windows.Forms.CheckBox)sender).Checked.ToString();
		}

		private void mouseEnter_MouseEnter(object sender, EventArgs e)
		{
			Control parent = (sender as System.Windows.Forms.GroupBox).Parent;
			parent.Focus();
		}

		private void mouseLeave_MouseLeave(object sender, EventArgs e)
		{
			Control parent = (sender as System.Windows.Forms.Control).Parent;
			Control grandparent = (parent as System.Windows.Forms.Control).Parent;
			grandparent.Focus();
		}
		#endregion

		public override string ToString()
		{
			string s = "URL: " + Url + Environment.NewLine + "Type: " + Type + Environment.NewLine + "Optional: " + Optional.ToString();
			return s;
		}

		/// <summary>
		/// Builds a ParameterDef panel form
		/// </summary>
		/// <returns>Returns a ParameterDef groupbox with all forms</returns>
		private Control buildNewParameterForm()
		{
			// create a new group box for the new ParameterDef
			this.Size = new System.Drawing.Size(523, 60);
			this.Text = "Parameter";
			this.MouseEnter += new System.EventHandler(this.mouseEnter_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.mouseLeave_MouseLeave);

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
			if (!String.IsNullOrEmpty(Optional))
				optionalCheckbox.Checked = Optional.ToLower().Equals("true");
			else { optionalCheckbox.Checked = false; }
			this.Controls.Add(optionalCheckbox);

			return this;
		}

	}
}
