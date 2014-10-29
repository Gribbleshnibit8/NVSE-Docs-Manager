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

		public void populateForm()
		{
			listBoxExamples.Items.Clear();
			richTextBoxExampleEditor.Clear();
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
					exampleText = Variables.ExampleList[listBoxExamples.SelectedIndex].Contents;
					foreach (string s in Variables.ExampleList[listBoxExamples.SelectedIndex].Contents)
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
					Variables.ExampleList[listBoxExamples.SelectedIndex].Contents.Clear();
					foreach (string line in richTextBoxExampleEditor.Lines)
					{
						Variables.ExampleList[listBoxExamples.SelectedIndex].Contents.Add(System.Web.HttpUtility.HtmlEncode(line));
					}
				}
			}

			private void listboxExamples_KeyUp(object sender, KeyEventArgs e)
			{
				switch (e.KeyCode)
				{
					case Keys.Delete:
						if (listBoxExamples.SelectedItems.Count > 0)
						{
							DialogResult d = MessageBox.Show("Are you sure you want to delete the selected Example(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							if (d == DialogResult.Yes)
							{
								for (int i = listBoxExamples.SelectedItems.Count - 1; i >= 0; i--)
								{
									Variables.ExampleList.RemoveAt(listBoxExamples.SelectedIndices[i]);
									listBoxExamples.Items.Remove(listBoxExamples.SelectedItems[i]);
								}
							}
						}
						break;

					default:
						break;
				}
			}

			private void buttonAddExample_Click(object sender, EventArgs e)
			{
				int i = listBoxExamples.Items.Count + 1;
				listBoxExamples.Items.Add("Example " + i);

				if (Variables.ExampleList == null)
				{
					Variables.ExampleList = new List<Example>();
				}
				Variables.ExampleList.Add(new Example());
			}

			private void buttonDone_Click(object sender, EventArgs e)
			{
				this.Close();
			}

		#endregion Events



	}
}
