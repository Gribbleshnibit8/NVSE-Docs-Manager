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

		Control _panel;
		public string Url { get; set; }
		public string Type { get; set; }
		public string Optional { get; set; }
		public string[] UrlBoxContents { get; set; }
		public string[] TypeBoxContents { get; set; }
		public string[] NameBoxContents { get; set; }

		#region Constructors
		public Parameter()
		{
			Url = "";
			Type = ":";
			Optional = "False";
			UrlBoxContents = new string[1] { "" };
			TypeBoxContents = new string[1] { "" };
			NameBoxContents = new string[1] { "" };
			_panel = BuildNewParameterForm();
		}

		/// <summary>
		/// Represents a groupbox of default controls consistent with the Parameter data type
		/// </summary>
		/// <param name="urlArray">A list of url hash strings</param>
		/// <param name="typeArray">A list of all values that can be of type type (Ex. integer, boolean, string)</param>
		/// <param name="nameArray">A list of all values that can be a name</param>
		public Parameter(string[] urlArray, string[] typeArray, string[] nameArray)
		{
			Url = "";
			Type = ":";
			Optional = "False";
			UrlBoxContents = urlArray;
			TypeBoxContents = typeArray;
			NameBoxContents = nameArray;
			_panel = BuildNewParameterForm();
		}

		/// <summary>
		/// Represents a groupbox of default controls consistent with the Parameter data type
		/// </summary>
		/// <param name="url">The page hash with information of this data type</param>
		/// <param name="type">The data represented by this parameter</param>
		/// <param name="optional">Is an optional parameter</param>
		/// <param name="urlArray">A list of url hash strings</param>
		/// <param name="typeArray">A list of all values that can be of type type (Ex. integer, boolean, string)</param>
		/// <param name="nameArray">A list of all values that can be a name</param>
		public Parameter(string url, string type, string optional, string[] urlArray, string[] typeArray, string[] nameArray)
		{
			Url = url;
			Type = type;
			Optional = optional;
			UrlBoxContents = urlArray;
			TypeBoxContents = typeArray;
			NameBoxContents = nameArray;
			_panel = BuildNewParameterForm();
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
			UrlBoxContents = toCopy.UrlBoxContents;
			TypeBoxContents = toCopy.TypeBoxContents;
			NameBoxContents = toCopy.NameBoxContents;
			_panel = BuildNewParameterForm();
		}
		#endregion

		#region Getters/Setters
		private static string GetTypeType(string type)
		{
			var s = type.Split(':');
			return s.Length >= 1 ? s[0] : "";
		}

		private static string GetTypeName(string type)
		{
			var s = type.Split(':');
			return s.Length >= 2 ? s[1] : "";
		}

		internal string SetTypeType(string type)
		{
			var t = Type.Split(':');
			t[0] = type;
			return t.Length == 1 ? t[0] + ":" : t[0] + ":" + t[1];
		}

		internal string SetTypeName(string type)
		{
			var t = Type.Split(':');
			t[1] = type;
			return String.IsNullOrEmpty(t[0]) ? ":" + t[1] : t[0] + ":" + t[1];
		}
		#endregion

		#region Event Handlers
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
			Type = SetTypeType(s);
		}

		private void nameBox_KeyUp(object sender, EventArgs e)
		{
			string s = ((System.Windows.Forms.ComboBox)sender).Text;
			Type = SetTypeName(s);
		}

		private void optionalBox_CheckedChanged(object sender, EventArgs e)
		{
			Optional = ((System.Windows.Forms.CheckBox)sender).Checked.ToString();
		}
		#endregion

		/// <summary>
		/// Builds a ParameterDef panel form
		/// </summary>
		/// <returns>Returns a ParameterDef groupbox with all forms</returns>
		private Control BuildNewParameterForm()
		{
			// create a new group box for the new ParameterDef
			this.Size = new System.Drawing.Size(523, 60);
			this.Text = "Parameter";

			// create the remove button
			using (var removeButton = new System.Windows.Forms.Button())
			{
				removeButton.Click += new System.EventHandler(this.removeParameter_Click);
				removeButton.Text = "X";
				removeButton.Location = new System.Drawing.Point(6, 16);
				removeButton.Size = new System.Drawing.Size(23, 37);
				this.Controls.Add(removeButton);
			}


			// URL
			// create the URL label and add it to the group box
			var urlLabel = new System.Windows.Forms.Label
			{
				Text = "URL:",
				Location = new System.Drawing.Point(33, 16),
				AutoSize = true
			};
			this.Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
			var urlCombobox = new System.Windows.Forms.ComboBox
			{
				Location = new System.Drawing.Point(36, 32),
				Name = "comboBoxURL",
				Sorted = true,
				Size = new System.Drawing.Size(140, 21),
				DropDownStyle = ComboBoxStyle.DropDownList,
				Text = Url
			};
			urlCombobox.SelectedIndexChanged += new EventHandler(this.urlBox_SelectedIndexChanged);
			urlCombobox.Items.AddRange(UrlBoxContents);
			this.Controls.Add(urlCombobox);

			// Type
			// create the Type label and add it to the group box
			var typeLabel = new System.Windows.Forms.Label
			{
				Text = "Type:",
				Location = new System.Drawing.Point(179, 16),
				AutoSize = true
			};
			this.Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
			var typeCombobox = new System.Windows.Forms.ComboBox
			{
				Location = new System.Drawing.Point(182, 32),
				Sorted = true,
				Name = "comboBoxType",
				Size = new System.Drawing.Size(140, 21)
			};
			typeCombobox.KeyUp += new KeyEventHandler(this.typeBox_KeyUp);
			typeCombobox.Items.AddRange(TypeBoxContents);
			typeCombobox.Text = GetTypeType(Type);
			this.Controls.Add(typeCombobox);

			// Name
			// create the Type label and add it to the group box
			var nameLabel = new System.Windows.Forms.Label
			{
				Location = new System.Drawing.Point(325, 16),
				Text = "Name:",
				AutoSize = true
			};
			this.Controls.Add(nameLabel);
			// create the Type combobox and add it to the group box
			var nameCombobox = new System.Windows.Forms.ComboBox
			{
				Location = new System.Drawing.Point(328, 32),
				Sorted = true,
				Size = new System.Drawing.Size(140, 21),
				Text = GetTypeName(Type),
				Name = "comboBoxName"
			};
			nameCombobox.KeyUp += new KeyEventHandler(this.nameBox_KeyUp);
			nameCombobox.Items.AddRange(NameBoxContents);
			this.Controls.Add(nameCombobox);

			// Optional
			var optionalCheckbox = new System.Windows.Forms.CheckBox
			{
				Location = new System.Drawing.Point(471, 15),
				Name = "checkBoxOptional",
				Text = "Optional",
				AutoSize = true,
				CheckAlign = ContentAlignment.BottomCenter,
				TextAlign = ContentAlignment.TopCenter
			};
			optionalCheckbox.CheckedChanged += new EventHandler(this.optionalBox_CheckedChanged);
			if (!String.IsNullOrEmpty(Optional))
				optionalCheckbox.Checked = Optional.ToLower().Equals("true");
			else { optionalCheckbox.Checked = false; }
			this.Controls.Add(optionalCheckbox);

			return this;
		}

	}
}
