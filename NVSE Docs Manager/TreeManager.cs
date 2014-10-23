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
	class TreeManager
	{

		private TreeNode tn;

		private void treeView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			tn = e.Item as TreeNode;
			DoDragDrop(e.Item.ToString(), DragDropEffects.Move);
		}
		private void treeView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			pt = MainWindow.treeView1.PointToClient(pt);
			TreeNode ParentNode = treeView1.GetNodeAt(pt);
			ParentNode.Nodes.Add(tn.Text); // this copies the node 
			tn.Remove(); // need to remove the original version of the node 
		}
		private void treeView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

	}
}
