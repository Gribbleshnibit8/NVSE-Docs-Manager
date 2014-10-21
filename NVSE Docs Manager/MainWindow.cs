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

using System.Json;
using Newtonsoft;
using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{
	public partial class MainWindow : Form
	{

		// array for parameters groups for each parameter
		List<Control> parametersList = new List<Control>();
		string[] paramaterURLs = new string[] { 
			"Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
		};

		// input file
		StreamReader inFile;

		// array of read in functions
		List<FunctionDef> functionsList = new List<FunctionDef>();


		public MainWindow()
		{
			InitializeComponent();

			// register mouse event handlers
			this.textBoxName.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			//this.nameTextBox.MouseHover += new System.EventHandler(this.formMouseEventHandler_MouseHover);
			this.textBoxName.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxAlias.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxAlias.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxVersion.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxVersion.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.groupBoxCallingConvention.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.groupBoxCallingConvention.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
				this.radioButtonCallingConventionRef.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
				this.radioButtonCallingConventionRef.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
				this.radioButtonCallingConventionBase.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
				this.radioButtonCallingConventionBase.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
				this.radioButtonCallingConventionEither.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
				this.radioButtonCallingConventionEither.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.groupBoxConditional.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.groupBoxConditional.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
				this.radioButtonConditionalTrue.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
				this.radioButtonConditionalTrue.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);
				this.radioButtonConditionalFalse.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
				this.radioButtonConditionalFalse.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxOrigin.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxOrigin.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.textBoxCategory.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.textBoxCategory.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

			this.flowLayoutPanelParameters.MouseEnter += new System.EventHandler(this.formMouseEventHandler_MouseEnter);
			this.flowLayoutPanelParameters.MouseLeave += new System.EventHandler(this.formMouseEventHandler_MouseLeave);

		}


		private void outputToStatusbar(string s)
		{
			toolStripStatusLabel1.Text = s;
		}
	// Tool strip handlers
		private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				inFile = new StreamReader(openFileDialog1.FileName);
				//MessageBox.Show(inFile.ReadToEnd());
				parseLoadedFile(inFile);
				inFile.Close();
			}
		}

		private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				saveFileDialog1.Filter = "Json Files (.json)|*.json|Text Files(*.*)|*.*";
				StreamReader sr = new
				   StreamReader(saveFileDialog1.FileName);
				MessageBox.Show(sr.ReadToEnd());
				sr.Close();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				System.Windows.Forms.Application.Exit();
			} 
		}
	// End tool strip handlers

		private void parseLoadedFile(StreamReader file)
		{
			//FunctionList newFunc = JsonConvert.DeserializeObject<FunctionList>(file.ReadToEnd());
			//Console.WriteLine(newFunc.ToString());
			//MessageBox.Show(newFunc.ToString());

			string json = @"{
		'Name': 'GetModINISetting',
		'Alias': 'GetModINI',
		'Parameters': [
			{'type': 'string:INIKeyPath'}
		],
		'ReturnType': [
			{'type': 'float:INIValue'}
		],
		'Version': '1.0',
		'Condition': ' No',
		'Convention': 'B',
		'Description': [
			'Returns a float value for the key in the Path string.',
			'The Path string contains the INI name, the App name, and the Key name. The format is \'iniName\/appName\/keyName\' with the separators being : \/ or \\ characters. The INI name corresponds to a file in \\Data\\Config\\ and does not include the \'.ini\' suffix.',
			'Returns default value of 0 if the Path string is erroneous, if the INI file does not exist, or if the App and\/or Key do not exist in the file',
			'The activity of MCM\'s INI functions is logged in the mcm.log file, located in the game\'s main directory, if you need to see what is being passed through the plugin.'
		],
		'Examples': [
			{'Example': [
				'GetModINI \'ExampleMenu\/Variables\/Variable1\''
			]}
		],
		'Tags': ['MCM'],
		'FromPlugin': 'MCM'
	}";
			List<FunctionDef> functionList = new List<FunctionDef>();

			//functionList = JsonConvert.DeserializeObject<List<FunctionDef>>(json);

			//functionList = JsonConvert.DeserializeObject<List<FunctionDef>>(json);
			//FunctionDef func = JsonConvert.DeserializeObject<FunctionDef>(json);
			//Console.WriteLine(func.Name);

			//JsonTextReader reader = new JsonTextReader(file);
			//JsonSerializer se = new JsonSerializer();
			//object parsedData = se.Deserialize(reader);

			

		}


		private void buttonSaveCurrentChanges_Click(object sender, EventArgs e)
		{
			FunctionDef func = new FunctionDef();

			func.Name = textBoxName.Text;
			func.Alias = textBoxAlias.Text;
			func.Version = textBoxVersion.Text;
			func.FromPlugin = textBoxOrigin.Text;
			func.Category = textBoxCategory.Text;

			if (textBoxTags.Text != "")
				func.Tags.AddRange(textBoxTags.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
			

			if (radioButtonCallingConventionBase.Checked == true)
				func.Convention = "B";
			else if (radioButtonCallingConventionEither.Checked == true)
				func.Convention = "E";
			else if (radioButtonCallingConventionRef.Checked == true)
				func.Convention = "R";

			// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
			if (radioButtonConditionalFalse.Checked == true)
				func.Condition = "No";
			else
				func.Condition = "Yes";

			foreach (Control c in parametersList)
			{
				Parameter newParam = new Parameter();

				System.Windows.Forms.ComboBox cBox;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboboxURL"];
				newParam.url = cBox.SelectedText;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxType"];
				newParam.type = cBox.SelectedText;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxOptional"];
				newParam.optional = cBox.SelectedText;

				func.Parameters.Add(newParam);
			}

			functionsList.Add(func);
			listboxFunctionList.Items.Add(func.Name);

		}

		private void listboxFunctionList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listboxFunctionList.SelectedItem != null)
			{
				MessageBox.Show(listboxFunctionList.SelectedItem.ToString());

				FunctionDef func = functionsList.ElementAt(listboxFunctionList.SelectedIndex);

				textBoxName.Text = func.Name;
				textBoxAlias.Text = func.Alias;
				textBoxVersion.Text = func.Version;
				textBoxOrigin.Text = func.FromPlugin;
				textBoxCategory.Text = func.Category;

				if (func.Tags != null)
					foreach (string s in func.Tags) { textBoxTags.Text += s + System.Environment.NewLine; }

				if (func.Convention == "B")
					radioButtonCallingConventionBase.Checked = true;
				else if (func.Convention == "E")
					radioButtonCallingConventionEither.Checked = true;
				else if (func.Convention == "R")
					radioButtonCallingConventionRef.Checked = true;

				// TODO: Change from Yes/No to T/F or Y/N and update javascript to match
				if (func.Condition == "No")
					radioButtonConditionalFalse.Checked = true;
				else
					radioButtonConditionalTrue.Checked = true;

				//foreach (Control c in parametersList)
				//{
				//	Parameter newParam = new Parameter();

				//	System.Windows.Forms.ComboBox cBox;

				//	cBox = (System.Windows.Forms.ComboBox)c.Controls["comboboxURL"];
				//	newParam.url = cBox.SelectedText;

				//	cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxType"];
				//	newParam.type = cBox.SelectedText;

				//	cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxOptional"];
				//	newParam.optional = cBox.SelectedText;

				//	func.Parameters.Add(newParam);
				//}

				//functionsList.Add(func);
				//listboxFunctionList.Items.Add(func.Name);

			}
		}

	}
}
