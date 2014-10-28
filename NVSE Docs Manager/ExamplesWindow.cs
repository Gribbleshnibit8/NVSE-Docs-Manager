using System;
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
	public partial class ExamplesWindow : Form
	{

		List<string> exampleText;

		public ExamplesWindow()
		{
			InitializeComponent();
			populateForm();
		}

		public static void updateTrgger()
		{
			populateForm();
		}

		private void populateForm()
		{
			if (Variables.ExampleList != null)
				for (int i = 0; i < Variables.ExampleList.Count; i++)
				{
					listBoxExamples.Items.Add("Example " + (i+1));
				}
		}


		#region Events
			private void listBoxExamples_MouseClick(object sender, MouseEventArgs e)
			{
				if (listBoxExamples.SelectedItem != null)
				{
					richTextBoxExampleEditor.Clear();
					exampleText = Variables.ExampleList[listBoxExamples.SelectedIndex].Example;
					foreach (string s in Variables.ExampleList[listBoxExamples.SelectedIndex].Example)
					{
						richTextBoxExampleEditor.Text += System.Web.HttpUtility.HtmlDecode(s) + System.Environment.NewLine;
					}
				}
			}

			/// <summary>
			/// Saves the contents of the Example Editor field on each key up
			/// </summary>
			private void ExampleEditor_KeyUp(object sender, KeyEventArgs e)
			{
				if (listBoxExamples.SelectedItem != null)
				{
					foreach (string s in Variables.ExampleList[listBoxExamples.SelectedIndex].Example)
					{
						richTextBoxExampleEditor.Text += System.Web.HttpUtility.HtmlDecode(s) + System.Environment.NewLine;
					}
				}


				//if (!String.IsNullOrEmpty(richTextBoxDescription.Text))
				//{
				//	if (function.Description == null) { function.Description = new List<string>(); }
				//	function.Description.Clear();
				//	foreach (string line in richTextBoxDescription.Lines)
				//	{
				//		if (function.Description.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
				//			function.Description.Add(System.Web.HttpUtility.HtmlEncode(line));
				//	}
				//}

			}

		#endregion Events










	}
}
