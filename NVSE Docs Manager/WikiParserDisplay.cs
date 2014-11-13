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
	public partial class WikiParserDisplay : Form
	{
		public WikiParserDisplay()
		{
			InitializeComponent();
		}

		public void ClearWindow()
		{
			this.richTextBox1.Clear();
		}

		public void PopulateForm(List<string> list)
		{
			foreach (var s in list)
			{
				richTextBox1.AppendText(s);
				richTextBox1.AppendText("\n");
			}
		}
	}
}
