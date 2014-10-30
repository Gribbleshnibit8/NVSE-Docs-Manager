using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVSE_Docs_Manager
{
	public class Common
	{

		/// <summary>
		/// Shows a message box asking if the user wants to delete an item or selection.
		/// </summary>
		/// <param name="typeToDelete">The name of the item or selection that will be deleted</param>
		/// <returns>DialogResult Yes or No depending on selection</returns>
		public static DialogResult ConfirmDelete(string typeToDelete)
		{
			return MessageBox.Show("Are you sure you want to delete the selected " + typeToDelete + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		/// <summary>
		/// Presents a Yes/No dialog option asking if the user has saved.
		/// Returns Yes or No
		/// </summary>
		public static DialogResult ConfirmCloseForm()
		{
			var d = MessageBox.Show("Have you saved?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
			if (d != DialogResult.Yes) return DialogResult.No;
			return DialogResult.Yes;
		}

		/// <summary>
		/// Presents a dialog form with a text entry.
		/// </summary>
		/// <param name="title">Title of the form.</param>
		/// <param name="promptText">Text prompt to inform what the entered string is for.</param>
		/// <param name="value">String variable to hold the entered text.</param>
		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			var form = new Form
			{
				ClientSize = new Size(396, 107),
				FormBorderStyle = FormBorderStyle.FixedDialog,
				StartPosition = FormStartPosition.CenterParent,
				MinimizeBox = false,
				MaximizeBox = false
			};
			var label = new Label {AutoSize = true};
			var textBox = new TextBox();
			var buttonOk = new Button
			{
				Text = "OK",
				DialogResult = DialogResult.OK,
				Anchor = AnchorStyles.Bottom | AnchorStyles.Right
			};
			var buttonCancel = new Button
			{
				Text = "Cancel",
				DialogResult = DialogResult.Cancel,
				Anchor = AnchorStyles.Bottom | AnchorStyles.Right
			};

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;


			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;

			form.Controls.AddRange(new Control[] {label, textBox, buttonOk, buttonCancel});
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			var dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

	}
}
