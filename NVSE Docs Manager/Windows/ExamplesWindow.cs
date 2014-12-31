using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NVSE_Docs_Manager.Classes;

namespace NVSE_Docs_Manager.Windows
{
	public partial class ExamplesWindow : Form
	{

		private List<string> _exampleText;

		private Variables _instanceVariables;

		public ExamplesWindow()
		{
			InitializeComponent();
		}

		public void SetInstanceVariable(ref Variables instance)
		{
			_instanceVariables = instance;
		}

		public void PopulateForm()
		{
			listBoxExamples.Items.Clear();
			richTextBoxExampleEditor.Clear();
			if (!_instanceVariables.IsExampleListNull())
				for (int i = 0; i < _instanceVariables.GetExampleList().Count; i++)
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
					richTextBoxExampleEditor.Enabled = true;
					_exampleText = _instanceVariables.GetExampleList()[listBoxExamples.SelectedIndex].Contents;
					foreach (var s in _instanceVariables.GetExampleList()[listBoxExamples.SelectedIndex].Contents)
					{
						richTextBoxExampleEditor.Text += System.Web.HttpUtility.HtmlDecode(s) + System.Environment.NewLine;
					}
				}
				else
				{
					richTextBoxExampleEditor.Enabled = false;
				}
			}

			/// <summary>
			/// Saves the contents of the Example Editor field on each key up
			/// </summary>
			private void ExampleEditor_KeyUp(object sender, KeyEventArgs e)
			{
				if (listBoxExamples.SelectedItem != null)
				{
					var index = listBoxExamples.SelectedIndex;
					var lines = richTextBoxExampleEditor.Lines.ToArray();
					_instanceVariables.UpdateExampleAtIndex(index, lines);
				}
			}

			private void listboxExamples_KeyUp(object sender, KeyEventArgs e)
			{
				switch (e.KeyCode)
				{
					case Keys.Delete:
						if (listBoxExamples.SelectedItems.Count > 0 && Common.ConfirmDelete("Example(s)"))
						{
							var index = listBoxExamples.SelectedItems.Count;

							for (int i = index - 1; i >= 0; i--)
							{
								_instanceVariables.RemoveExample(index);
								listBoxExamples.Items.Remove(listBoxExamples.SelectedItems[i]);
							}
						}
						if (listBoxExamples.Items.Count == 0)
							richTextBoxExampleEditor.Enabled = false;
						break;

					default:
						break;
				}
			}

			private void buttonAddExample_Click(object sender, EventArgs e)
			{
				int i = listBoxExamples.Items.Count + 1;
				listBoxExamples.Items.Add("Example " + i);

				_instanceVariables.AddExample();

				// set the first item selected and enable the editing field
				if (listBoxExamples.SelectedIndex == -1)
				{
					listBoxExamples.SelectedIndex = 0;
					richTextBoxExampleEditor.Enabled = true;
				}
			}

			private void buttonDone_Click(object sender, EventArgs e)
			{
				Close();
			}

		#endregion Events

	}
}
