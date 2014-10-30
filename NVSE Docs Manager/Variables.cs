using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVSE_Docs_Manager
{
	public class Variables
	{

		public static List<Example> ExampleList = new List<Example>();

		/// <summary>
		/// Stores the current function prior to any changes
		/// </summary>
		public static FunctionDef CurrentEditingBackup = new FunctionDef();

		/// <summary>
		/// A list of Parameter Control objects displayed in the current form
		/// </summary>
		public static List<Control> ParametersList = new List<Control>();

		/// <summary>
		/// A list of all the names from the left-hand side of the ParameterDef type
		/// </summary>
		public static List<string> ParameterTypesList = new List<string>();

		/// <summary>
		/// A list of all the names from the right-hand side of the ParameterDef type
		/// </summary>
		public static List<string> ParameterNamesList = new List<string>();

		/// <summary>
		/// List of all loaded functions
		/// </summary>
		public static List<FunctionDef> LoadedFunctionsList = new List<FunctionDef>();


		public static List<string> ParameterUrlList = new List<string>() { 
			"Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Format_Specifiers", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
		};
	}
}
