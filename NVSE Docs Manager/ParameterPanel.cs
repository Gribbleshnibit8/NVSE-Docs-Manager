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
		public string Value { get; set; }
		public object[] UrlBoxContents { get; set; }
		public object[] TypeBoxContents { get; set; }
		public object[] NameBoxContents { get; set; }

		#region Constructors
		public Parameter()
		{
			Url = "";
			Type = ":";
			Optional = "False";
			UrlBoxContents = new object[1] { "" };
			TypeBoxContents = new object[1] { "" };
			NameBoxContents = new object[1] { "" };
			_panel = BuildNewParameterForm();
		}

		/// <summary>
		/// Represents a groupbox of default controls consistent with the Parameter data type
		/// </summary>
		/// <param name="urlArray">A list of url hash strings</param>
		/// <param name="typeArray">A list of all values that can be of type type (Ex. integer, boolean, string)</param>
		/// <param name="nameArray">A list of all values that can be a name</param>
		public Parameter(object[] urlArray, object[] typeArray, object[] nameArray)
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
		public Parameter(string url, string type, string optional, object[] urlArray, object[] typeArray, object[] nameArray)
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
				if (type != null)
				{
					var s = type.Split(':');
					return s.Length >= 1 ? s[0] : "";
				}
				return null;
			}

			private static string GetTypeName(string type)
			{
				if (type != null)
				{
					var s = type.Split(':');
					return s.Length >= 2 ? s[1] : "";
				}
				return null;
			}

			internal string SetTypeType(string type)
			{
				if (Type != null)
					{
						var t = Type.Split(':');
						t[0] = type;
						return t.Length == 1 ? t[0] + ":" : t[0] + ":" + t[1];
					}
				return null;
			}

			internal string SetTypeName(string type)
			{
				if (Type != null)
					{
						var t = Type.Split(':');
						t[1] = type;
						return String.IsNullOrEmpty(t[0]) ? ":" + t[1] : t[0] + ":" + t[1];
					}
				return null;
			}

		#endregion

		#region Event Handlers
			private void removeParameter_Click(object sender, System.EventArgs e)
			{
				var parent = ((Button) sender).Parent;
				var grandparent = ((GroupBox) parent).Parent;
				grandparent.Controls.Remove(parent);
				//rebuildParamaterPanel();
			}

			protected void urlBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				Url = ((ComboBox)sender).Text;
			}

			protected void typeBox_KeyUp(object sender, EventArgs e)
			{
				//if (((ComboBox) sender).DroppedDown == false)
				//	((ComboBox) sender).DroppedDown = true;

				var s = ((ComboBox)sender).Text;
				Type = SetTypeType(s);
			}

			protected void nameBox_KeyUp(object sender, EventArgs e)
			{
				//if (((ComboBox)sender).DroppedDown == false)
				//	((ComboBox)sender).DroppedDown = true;
				var s = ((ComboBox)sender).Text;
				Type = SetTypeName(s);
			}

			protected void optionalBox_CheckedChanged(object sender, EventArgs e)
			{
				Optional = ((CheckBox)sender).Checked.ToString();
			}
		#endregion

		/// <summary>
		/// Builds a ParameterDef panel form
		/// </summary>
		/// <returns>Returns a ParameterDef groupbox with all forms</returns>
		private Control BuildNewParameterForm()
		{
			// create a new group box for the new ParameterDef
			Size = new Size(523, 60);
			Text = "Parameter";

			// create the remove button
			var removeButton = new Button()
			{
				Text = "X",
				Location = new Point(6,16),
				Size = new Size(23, 37)
			};
			removeButton.Click += removeParameter_Click;
			Controls.Add(removeButton);

			// URL
			// create the URL label and add it to the group box
			var urlLabel = new Label
			{
				Text = "URL:",
				Location = new System.Drawing.Point(33, 16),
				AutoSize = true
			};
			Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
			var urlCombobox = new ComboBox
			{
				Name = "comboBoxURL",
				Location = new Point(36, 32),
				Sorted = true,
				Size = new Size(140, 21),
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			urlCombobox.SelectedIndexChanged += this.urlBox_SelectedIndexChanged;
			urlCombobox.Items.AddRange(UrlBoxContents);
			urlCombobox.Text = Url;
			Controls.Add(urlCombobox);

			// Type
			// create the Type label and add it to the group box
			var typeLabel = new Label
			{
				Text = "Type:",
				Location = new System.Drawing.Point(179, 16),
				AutoSize = true
			};
			Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
			var typeCombobox = new ComboBox
			{
				Name = "comboBoxType",
				Location = new Point(182, 32),
				Sorted = true,
				Size = new Size(140, 21),
				AutoCompleteMode = AutoCompleteMode.Suggest,
				AutoCompleteSource = AutoCompleteSource.ListItems
			};
			typeCombobox.KeyUp += this.typeBox_KeyUp;
			typeCombobox.Items.AddRange(TypeBoxContents);
			typeCombobox.Text = GetTypeType(Type);
			Controls.Add(typeCombobox);

			// Name
			// create the Type label and add it to the group box
			var nameLabel = new Label
			{
				Location = new System.Drawing.Point(325, 16),
				Text = "Name:",
				AutoSize = true
			};
			this.Controls.Add(nameLabel);
			// create the Type combobox and add it to the group box
			var nameCombobox = new ComboBox
			{
				Name = "comboBoxName",
				Location = new Point(328, 32),
				Sorted = true,
				Size = new Size(140, 21),
				AutoCompleteSource = AutoCompleteSource.ListItems,
				AutoCompleteMode = AutoCompleteMode.SuggestAppend
			};
			nameCombobox.KeyUp += this.nameBox_KeyUp;
			nameCombobox.Items.AddRange(NameBoxContents);
			nameCombobox.Text = GetTypeName(Type);
			Controls.Add(nameCombobox);

			// Optional
			var optionalCheckbox = new CheckBox
			{
				Name = "checkBoxOptional",
				Text = "Optional",
				Location = new Point(471, 15),
				AutoSize = true,
				CheckAlign = ContentAlignment.BottomCenter,
				TextAlign = ContentAlignment.TopCenter
			};
			optionalCheckbox.CheckedChanged += this.optionalBox_CheckedChanged;
			optionalCheckbox.Checked = !String.IsNullOrEmpty(Optional) && Optional.ToLower().Equals("true");
			Controls.Add(optionalCheckbox);

			return this;
		}

	}
}
