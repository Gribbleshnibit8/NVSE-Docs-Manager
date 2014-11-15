using System;
using System.Drawing;
using System.Windows.Forms;

namespace NVSE_Docs_Manager
{
	public class Common
	{

		/// <summary>
		/// Shows a message box asking if the user wants to delete an item or selection.
		/// </summary>
		/// <param name="typeToDelete">The name of the item or selection that will be deleted</param>
		/// <returns>Returns true if Yes</returns>
		public static bool ConfirmDelete(string typeToDelete)
		{
			return MessageBox.Show("Are you sure you want to delete the selected " + typeToDelete + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		/// /// <summary>
		/// Presents a Yes/No dialog option asking if the user has saved.
		/// </summary>
		/// <returns>Returns true if Yes</returns>
		public static bool ConfirmCloseForm()
		{
			return MessageBox.Show("Have you saved?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes;
		}

		/// <summary>
		/// Presents a Yes/No dialog option asking if the user would like to update a function.
		/// </summary>
		/// <returnsReturns true if Yes</returns>
		public static bool ConfirmUpdateFunction()
		{
			return MessageBox.Show("This function already exists. Would you like to update it with the new information?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
		}

		/// <summary>
		/// Presents a Yes/No dialog option asking if the user is sure they want to discard chagnes.
		/// </summary>
		/// <returns>Returns true if Yes</returns>
		public static bool ConfirmDiscardChanges()
		{
			return MessageBox.Show("Are you sure you want to discard the changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

		}

		/// <summary>
		/// Presents a Yes/No dialog option asking if the user is sure they want to discard chagnes.
		/// </summary>
		/// <returns>Returns true if Yes</returns>
		public static bool ConfirmClearForm()
		{
			return MessageBox.Show("Are you sure you want to clear the form?", "New Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

		}

		/// <summary>
		/// Presents a dialog form with a text entry.
		/// </summary>
		/// <param name="title">Title of the form.</param>
		/// <param name="promptText">Text prompt to inform what the entered string is for.</param>
		/// <param name="value">String variable to hold the entered text.</param>
		public static bool InputBox(string title, string promptText, ref string value)
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

			value = textBox.Text;
			return form.ShowDialog() == DialogResult.OK;
		}

	}
}
