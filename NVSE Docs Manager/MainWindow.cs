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
		List<string> parameterURLList = new List<string>() { 
			"Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
		};
		List<string> parameterTypesList = new List<string>()
		{
			"scanCode:Integer"
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

			FunctionDef func = TestFunctionDef();

			functionsList.Add(func);
			listboxFunctionList.Items.Add(func.Name);

			//func = JsonConvert.DeserializeObject<FunctionDef>(json);

			//functionList = JsonConvert.DeserializeObject<List<FunctionDef>>(json);
			//FunctionDef func = JsonConvert.DeserializeObject<FunctionDef>(json);
			//Console.WriteLine(func.Name);

			//JsonTextReader reader = new JsonTextReader(file);
			//JsonSerializer se = new JsonSerializer();
			//object parsedData = se.Deserialize(reader);

			

		}

		public FunctionDef TestFunctionDef()
		{
			FunctionDef func = new FunctionDef();

			func.Name = "GetModINISetting";
			func.Alias = "GetModINI";
			func.Parameters.Add(new Parameter { type = "string:INIKeyPath" });
			func.ReturnType.type = "float:INIValue";
			func.Version = "1.0";
			func.Condition = "No";
			func.Convention = "B";
			func.Description.Add("Returs a float value for the key in the Path string.");
			func.Description.Add("The Path string contains the INI name, the App name, and the Key name. The format is \'iniName/appName/keyName\' with the separators being : / or \\ characters. The INI name corresponds to a file in \\Data\\Config\\ and does not include the \'.ini\' suffix.");
			func.Tags.Add("MCM");
			func.FromPlugin = "MCM";

			return func;
		}

		public void populateFunctionForm(FunctionDef func)
		{
			flowLayoutPanelParameters.Controls.Clear();
			parametersList.Clear();
			textBoxName.Clear();
			textBoxAlias.Clear();
			textBoxVersion.Clear();
			textBoxOrigin.Clear();
			textBoxCategory.Clear();
			textBoxTags.Clear();
			radioButtonCallingConventionEither.Checked = true;
			radioButtonConditionalFalse.Checked = true;

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

			populateParameterList(func.Parameters);

			if (!String.IsNullOrEmpty(func.ReturnType.type))
			{
				comboBoxReturnTypeURL.Text = func.ReturnType.url;
				comboBoxReturnTypeType.Text = func.ReturnType.type;
				checkBoxReturnType.Checked = true;
			}
			else
			{
				comboBoxReturnTypeURL.Text = "";
				comboBoxReturnTypeType.Text = "";
				checkBoxReturnType.Checked = false;
			}
		}



		private void saveNewFunction()
		{
			FunctionDef func = new FunctionDef();
			windowToFunction(func);
			functionsList.Add(func);
			listboxFunctionList.Items.Add(func.Name);
		}

		private void updateFunction(FunctionDef func)
		{
			windowToFunction(func);
		}

		private FunctionDef windowToFunction(FunctionDef func)
		{
			func.Name = textBoxName.Text;
			func.Alias = textBoxAlias.Text;
			func.Version = textBoxVersion.Text;
			func.FromPlugin = textBoxOrigin.Text;
			func.Category = textBoxCategory.Text;

			if (!String.IsNullOrEmpty(textBoxTags.Text))
			{
				foreach (string line in textBoxTags.Lines)
				{
					;
					if (func.Tags.IndexOf(line) == -1 && !String.IsNullOrEmpty(line))
						func.Tags.Add(line);
				}
				//func.Tags.AddRange(textBoxTags.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
			}
				


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

			func.Parameters.Clear();
			foreach (Control c in parametersList)
			{
				Parameter newParam = new Parameter();

				System.Windows.Forms.ComboBox cBox;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxURL"];
				newParam.url = cBox.Text;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxType"];
				newParam.type = cBox.Text;

				cBox = (System.Windows.Forms.ComboBox)c.Controls["comboBoxOptional"];
				newParam.optional = cBox.Text;

				func.Parameters.Add(newParam);
			}

			if (checkBoxReturnType.Checked)
			{
				func.ReturnType.url = comboBoxReturnTypeURL.Text;
				func.ReturnType.type = comboBoxReturnTypeType.Text;
			}
			return func;
		}

	}
}
