using System;
using System.Windows.Forms;
using NVSE_Docs_Manager.Classes;
using NVSE_Docs_Manager.Windows;

namespace NVSE_Docs_Manager.Controls
{
	public partial class ParameterBox : UserControl
	{

		public string Url { get; set; }
		public string Type { get; set; }
		public string Optional { get; set; }
		public string Value { get; set; }
		public object[] UrlBoxContents { get; set; }
		public object[] ValueBoxContents { get; set; }
		public object[] TypeBoxContents { get; set; }
		public object[] NameBoxContents { get; set; }

		public string Title
		{
			set { groupBoxParameter.Text = value; }
		}

		private readonly ToolTip _ttip = new ToolTip()
		{
			InitialDelay = 100
		};

		#region Constructors

			public ParameterBox()
			{
				InitializeComponent();
				Url = "";
				Type = ":";
				Optional = "False";
				Value = "";
				SetArrayValues(new Variables());
				InitializeElements();
			}

			public ParameterBox(Variables instanceVariables)
			{
				InitializeComponent();
				Url = "";
				Type = ":";
				Optional = "False";
				Value = "";
				SetArrayValues(instanceVariables);
				InitializeElements();
			}

			/// <summary>
			/// Create a new parameter from a ParameterDef object
			/// </summary>
			/// <param name="parameter">The new parameter from which to make a parameter panel.</param>
			/// <param name="instanceVariables">Instance of variables for the current form.</param>
			public ParameterBox(ParameterDef parameter, Variables instanceVariables)
			{
				InitializeComponent();
				Url = parameter.Url;
				Type = parameter.Type;
				Optional = parameter.Optional;
				Value = parameter.Value;
				SetArrayValues(instanceVariables);
				InitializeElements();
			}

			/// <summary>
			/// Copies one ParameterBox to a new one
			/// </summary>
			/// <param name="toCopy">ParameterBox Control to be copied</param>
			public ParameterBox(ParameterBox toCopy)
			{
				InitializeComponent();
				Url = toCopy.Url;
				Type = toCopy.Type;
				Optional = toCopy.Optional;
				Value = toCopy.Value;
				UrlBoxContents = toCopy.UrlBoxContents;
				ValueBoxContents = toCopy.ValueBoxContents;
				TypeBoxContents = toCopy.TypeBoxContents;
				NameBoxContents = toCopy.NameBoxContents;
				InitializeElements();
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

		/// <summary>
		/// Converts the parameter box data to a parameter def
		/// </summary>
		/// <returns>Box data as a ParameterDef</returns>
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

		private void InitializeElements()
		{
			comboBoxParameterURL.Text = Url;
			comboBoxParameterValue.Text = Value;
			if (Type != ":")
				comboBoxParameterType.Text = Type;
			comboBoxParameterName.Text = Name;
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
			private void RemoveParameter_Click(object sender, System.EventArgs e)
			{
				MainWindow.flowLayoutPanelParameters.Controls.Remove(this);
			}

			private void CopyParameter_Click(object sender, System.EventArgs e)
			{
				Control copy = new ParameterBox(this);
				MainWindow.flowLayoutPanelParameters.Controls.Add(copy);
				MainWindow.flowLayoutPanelParameters.Controls.SetChildIndex(copy, MainWindow.flowLayoutPanelParameters.Controls.GetChildIndex(this)+1);

				// Hacky workaround to make the list reorder numbers correctly after changing index above
				var temp = new ParameterBox();
				MainWindow.flowLayoutPanelParameters.Controls.Add(temp);
				MainWindow.flowLayoutPanelParameters.Controls.Remove(temp);
			}

			private void UrlBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				Url = ((ComboBox)sender).Text;
			}

			private void ValueBox_KeyUp(object sender, KeyEventArgs e)
			{
				Value = ((ComboBox)sender).Text;
			}

			private void TypeBox_KeyUp(object sender, KeyEventArgs e)
			{
				Type = SetTypeType(((ComboBox)sender).Text);
			}

			private void NameBox_KeyUp(object sender, KeyEventArgs e)
			{
				Type = SetTypeName(((ComboBox)sender).Text);
			}

			private void OptionalBox_CheckedChanged(object sender, EventArgs e)
			{
				Optional = ((CheckBox)sender).Checked.ToString();
			}
		#endregion

			
	}
}
