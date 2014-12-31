using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NVSE_Docs_Manager.Windows
{
	public partial class AboutWindow : Form
	{
		public AboutWindow()
		{
			InitializeComponent();
		}

		private void AboutWindow_Load(object sender, EventArgs e)
		{
			linkLabel1.Links.Add(0, 200, "http://www.gribbleshnibit.com/projects/NVSEDocs/");
			linkLabel2.Links.Add(0, 200, "http://opensource.org/licenses/GPL-3.0");
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
			Process.Start(sInfo);
		}
	}
}
