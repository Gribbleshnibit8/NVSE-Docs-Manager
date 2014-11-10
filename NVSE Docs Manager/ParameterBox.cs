using System;
using System.Drawing;
using System.Windows.Forms;

namespace NVSE_Docs_Manager
{
	public class ParameterBox : GroupBox
	{

		Control _panel;
		public string Url { get; set; }
		public string Type { get; set; }
		public string Optional { get; set; }
		public string Value { get; set; }
		public object[] UrlBoxContents { get; set; }
		public object[] ValueBoxContents { get; set; }
		public object[] TypeBoxContents { get; set; }
		public object[] NameBoxContents { get; set; }

		#region Constructors
			public ParameterBox()
			{
				Url = "";
				Type = ":";
				Optional = "False";
				Value = "";
				SetArrayValues(new Variables());
				_panel = BuildNewParameterForm();
			}


			public ParameterBox(Variables instanceVariables)
			{
				Url = "";
				Type = ":";
				Optional = "False";
				Value = "";
				SetArrayValues(instanceVariables);
				_panel = BuildNewParameterForm();
			}

			/// <summary>
			/// Create a new parameter from a ParameterDef object
			/// </summary>
			/// <param name="parameter">The new parameter from which to make a parameter panel.</param>
			/// <param name="instanceVariables">Instance of variables for the current form.</param>
			public ParameterBox(ParameterDef parameter, Variables instanceVariables)
			{
				Url = parameter.Url;
				Type = parameter.Type;
				Optional = parameter.Optional;
				Value = parameter.Value;
				SetArrayValues(instanceVariables);
				_panel = BuildNewParameterForm();
			}

			/// <summary>
			/// Copies one ParameterBox to a new one
			/// </summary>
			/// <param name="toCopy">ParameterBox Control to be copied</param>
			public ParameterBox(ParameterBox toCopy)
		{
			Url = toCopy.Url;
			Type = toCopy.Type;
			Optional = toCopy.Optional;
			Value = toCopy.Value;
			UrlBoxContents = toCopy.UrlBoxContents;
			ValueBoxContents = toCopy.ValueBoxContents;
			TypeBoxContents = toCopy.TypeBoxContents;
			NameBoxContents = toCopy.NameBoxContents;
			_panel = BuildNewParameterForm();
		}
		#endregion

		/// <summary>
		/// Gets the combo box value arrays from the variables class.
		/// </summary>
		private void SetArrayValues(Variables instanceVariables)
		{
			UrlBoxContents = instanceVariables.GetUrlObjectArray();
			ValueBoxContents = instanceVariables.GetValueObjectArray();
			TypeBoxContents = instanceVariables.GetTypeObjectArray();
			NameBoxContents = instanceVariables.GetNameObjectArray();
		}

		public ParameterDef ToParameterDef()
		{
			var newParam = new ParameterDef();
			if (!String.IsNullOrEmpty(Url))
				newParam.Url = Url;

			if (!String.IsNullOrEmpty(Type) && Type != ":")
				newParam.Type = Type;

			if (!String.IsNullOrEmpty(Optional))
				newParam.Optional = Optional;

			if (!String.IsNullOrEmpty(Value))
				newParam.Value = Value;

			return newParam;
		}

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
				var parentGroupBox = ((Button)sender).Parent;
				var grandparentFlowPanel = ((GroupBox)parentGroupBox).Parent;
				grandparentFlowPanel.Controls.Remove(parentGroupBox);
			}

			private void copyParameter_Click(object sender, System.EventArgs e)
			{
				var grandparentFlowPanel = ((GroupBox)((Button)sender).Parent).Parent;

				Control copy = new ParameterBox(this);
				grandparentFlowPanel.Controls.Add(copy);
				grandparentFlowPanel.Controls.SetChildIndex(copy, grandparentFlowPanel.Controls.GetChildIndex(this)+1);

				// Hacky workaround to make the list reorder numbers correctly after changing index above
				var temp = new ParameterBox();
				grandparentFlowPanel.Controls.Add(temp);
				grandparentFlowPanel.Controls.Remove(temp);
			}

			protected void urlBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				Url = ((ComboBox)sender).Text;
			}

			protected void valueBox_KeyUp(object sender, EventArgs e)
			{
				Value = ((ComboBox)sender).Text;
			}

			protected void typeBox_KeyUp(object sender, EventArgs e)
			{
				Type = SetTypeType(((ComboBox)sender).Text);
			}

			protected void nameBox_KeyUp(object sender, EventArgs e)
			{
				Type = SetTypeName(((ComboBox)sender).Text);
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
			Size = new Size(435, 70);
			Text = "ParameterBox";

			// create the remove button
			var removeButton = new Button()
			{
				Text = "X",
				Location = new Point(5,13),
				Size = new Size(23, 21)
			};
			removeButton.Click += removeParameter_Click;
			Controls.Add(removeButton);

			// create the copy button
			var copyButton = new Button()
			{
				Text = "C",
				Location = new Point(30, 13),
				Size = new Size(23, 21)
			};
			copyButton.Click += copyParameter_Click;
			Controls.Add(copyButton);

			// URL
			// create the URL label and add it to the group box
			var urlLabel = new Label
			{
				Text = "URL",
				Location = new System.Drawing.Point(59, 16),
				AutoSize = true
			};
			Controls.Add(urlLabel);
			// create the URL combobox and add it to the group box
			var urlCombobox = new ComboBox
			{
				Name = "comboBoxURL",
				Location = new Point(97, 13),
				Sorted = true,
				Size = new Size(140, 21),
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			urlCombobox.SelectedIndexChanged += this.urlBox_SelectedIndexChanged;
			urlCombobox.Items.AddRange(UrlBoxContents);
			urlCombobox.Text = Url;
			Controls.Add(urlCombobox);

			// Value
			// create teh Value lable and add it to the group box
			var valueLabel = new Label
			{
				Text = "Value",
				Location = new System.Drawing.Point(243, 16),
				AutoSize = true
			};
			Controls.Add(valueLabel);
			// create the URL combobox and add it to the group box
			var valueCombobox = new ComboBox
			{
				Name = "comboBoxValue",
				Location = new Point(283, 13),
				Sorted = true,
				Size = new Size(140, 21)
			};
			valueCombobox.KeyUp += this.valueBox_KeyUp;
			valueCombobox.Items.AddRange(ValueBoxContents);
			valueCombobox.Text = Value;
			Controls.Add(valueCombobox);

			// Type
			// create the Type label and add it to the group box
			var typeLabel = new Label
			{
				Text = "Type:",
				Location = new System.Drawing.Point(59, 43),
				AutoSize = true
			};
			Controls.Add(typeLabel);
			// create the Type combobox and add it to the group box
			var typeCombobox = new ComboBox
			{
				Name = "comboBoxType",
				Location = new Point(96, 40),
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
				Location = new System.Drawing.Point(243, 43),
				Text = "Name:",
				AutoSize = true
			};
			this.Controls.Add(nameLabel);
			// create the Type combobox and add it to the group box
			var nameCombobox = new ComboBox
			{
				Name = "comboBoxName",
				Location = new Point(284, 40),
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
				Location = new Point(6, 35),
				AutoSize = true,
				CheckAlign = ContentAlignment.BottomCenter
			};
			optionalCheckbox.CheckedChanged += this.optionalBox_CheckedChanged;
			optionalCheckbox.Checked = !String.IsNullOrEmpty(Optional) && Optional.ToLower().Equals("true");
			Controls.Add(optionalCheckbox);

			return this;
		}

	}
}
