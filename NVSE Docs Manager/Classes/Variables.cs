using System;
using System.Collections.Generic;
using System.Linq;

namespace NVSE_Docs_Manager
{
	public class Variables
	{

		private List<Example> ExampleList { get; set; }

		/// <summary>
		/// List of all loaded functions
		/// </summary>
		private List<FunctionDef> LoadedFunctionsList { get; set; } 

		/// <summary>
		/// Stores the current function prior to any changes
		/// </summary>
		private FunctionDef CurrentEditingBackup { get; set; }

		/// <summary>
		/// A list of all the reference types used by the loaded functions
		/// </summary>
		private List<string> ReferenceTypesList { get; set; }

		/// <summary>
		/// A list of all the names from the left-hand side of the ParameterDef type
		/// </summary>
		private List<string> ParameterTypesList { get; set; } 

		/// <summary>
		/// A list of all the names from the right-hand side of the ParameterDef type
		/// </summary>
		private List<string> ParameterNamesList { get; set; }

		/// <summary>
		/// The values all parameters that have been loaded or saved.
		/// </summary>
		private List<string> ParameterValuesList { get; set; } 


		/// <summary>
		/// A list of the URLs as used on the NVSE site page.
		/// </summary>
		private List<string> ParameterUrlList { get; set; }


		public Variables()
		{
			CurrentEditingBackup = new FunctionDef();
			LoadedFunctionsList = new List<FunctionDef>();
			ReferenceTypesList = new List<string>();
			ExampleList = new List<Example>();
			ParameterTypesList = new List<string>();
			ParameterNamesList = new List<string>();
			ParameterValuesList = new List<string>();
			ParameterUrlList = new List<string>() { 
			" ", "Actor_Flags", "Actor_Value_Codes", "Attack_Animations", "Biped_Path_Codes", "Control_Codes", "DirectX_Scancodes", 
			"Equip_Type", "Equipment_Slot_IDs", "Form_Type_IDs", "Format_Specifiers", "Reload_Animations", "Weapon_Flags", "Weapon_Hand_Grips", 
			"Weapon_Mod", "Weapon_Type"
			};
		}


		/// <summary>
		/// Updates the ParameterDef type and name lists from all parameters
		/// </summary>
		public void UpdateLists()
		{
			foreach (FunctionDef f in LoadedFunctionsList)
			{
				// Reference Types
				if (f.ReferenceType != null)
					if (!ReferenceTypesList.Contains(f.ReferenceType))
						ReferenceTypesList.Add(f.ReferenceType);

				// Parameters
				if (f.Parameters != null)
				{
					foreach (ParameterDef p in f.Parameters)
					{
						if (p.Type != null)
						{
							var s = p.Type.Split(':');
							if (!ParameterTypesList.Contains(s[0]) && !String.IsNullOrEmpty(s[0]))
								ParameterTypesList.Add(s[0]);

							if (s.Length >= 2 && !ParameterNamesList.Contains(s[1]) && !String.IsNullOrEmpty(s[1]))
								ParameterNamesList.Add(s[1]);
						}
						if (p.Value != null && !ParameterValuesList.Contains(p.Value))
						{
							ParameterValuesList.Add(p.Value);
						}
					}
				}
					
			}
		}



		#region LoadedFunctionLists Functions

			public bool FunctionExists(FunctionDef match)
			{
				if (LoadedFunctionsList.Exists(f => f.Name == match.Name))
					return true;
				return false;
			}

			public bool FunctionExists(string match)
			{
				if (LoadedFunctionsList.Exists(f => f.Name == match))
					return true;
				return false;
			}

			public FunctionDef GetFunctionByName(string toFind)
			{
				return LoadedFunctionsList.Find(f => f.Name == toFind);
			}

			/// <summary>
			/// Adds a function definition to the function list.
			/// </summary>
			/// <param name="toAdd">The function definition to add.</param>
			public void AddFunction(FunctionDef toAdd)
			{
				LoadedFunctionsList.Add(toAdd);
			}

			/// <summary>
			/// Returns the function list
			/// </summary>
			public List<FunctionDef> GetFunctionList()
			{
				return LoadedFunctionsList;
			}

			/// <summary>
			/// Remove a single function from the list
			/// </summary>
			/// <param name="toRemove">FunctionDef item to remove</param>
			public void RemoveFunction(FunctionDef toRemove)
			{
				LoadedFunctionsList.Remove(LoadedFunctionsList.Find(f => f.Name == toRemove.Name));
			}

			/// <summary>
			/// A list of function items to remove from the function list.
			/// </summary>
			/// <param name="toRemove">A ListBox.SelectedObjectCollection of Function names to remove from the function list.</param>
			public void RemoveFunction(object toRemove)
			{
				dynamic d = toRemove;
				for (int i = d.Count - 1; i >= 0; i--)
				{
					LoadedFunctionsList.Remove(LoadedFunctionsList.Find(f => f.Name == d[i].ToString()));
				}
			}

			public void UpdateTags(object toUpdate, string newValue)
			{
				dynamic d = toUpdate;
				foreach (string s in d)
				{
					LoadedFunctionsList.Find(f => f.Name == s).Tags.Add(s);
				}


			}

			public void CleanFunctionList()
			{
				foreach (var f in LoadedFunctionsList)
				{
					f.CleanFunctionDef();
				}
			}

		#endregion



		#region Backup Properties
			/// <summary>
			/// Sets the current backup field
			/// </summary>
			/// <param name="backup">The function to be saved</param>
			public void SetBackup(FunctionDef backup)
			{
				CurrentEditingBackup = backup;
			}

			/// <summary>
			/// Gets the current backup field
			/// </summary>
			/// <returns>The last backed up function</returns>
			public FunctionDef GetBackup()
			{
				return CurrentEditingBackup;
			}

			/// <summary>
			/// Checks if the backup function is valid
			/// </summary>
			/// <returns>True if backup is valid</returns>
			public bool IsBackupNull()
			{
				return CurrentEditingBackup == null;
			}
			#endregion



		#region Example List Properties

			public void SetExampleList(List<Example> list)
			{
				ExampleList = list;
			}

			/// <summary>
			/// Returns the example list, clean of all empty examples.
			/// </summary>
			/// <returns>Clean example list.</returns>
			public List<Example> GetExampleList ()
			{
				foreach (var e in ExampleList.Where(e => e.Contents == null))
					ExampleList.Remove(e);
				return ExampleList;
			}

			/// <summary>
			/// Checks whether or not the example list is null.
			/// </summary>
			/// <returns>Returns true if the list is null.</returns>
			public bool IsExampleListNull()
			{
				return ExampleList == null;
			}

			public void AddExample()
			{
				if (ExampleList != null) ExampleList.Add(new Example());
				else ExampleList = new List<Example>() {new Example()};
			}

		public void RemoveExample(int index)
			{
				ExampleList.RemoveAt(index);
			}

			/// <summary>
			/// Updates the example array at the specified index
			/// </summary>
			/// <param name="index">Index to update.</param>
			/// <param name="lines">Array of strings to add</param>
			public void UpdateExampleAtIndex(int index, string[] lines)
			{
				ExampleList[index].Contents.Clear();
				foreach (var s in lines)
				{
					ExampleList[index].Contents.Add(System.Web.HttpUtility.HtmlEncode(s));
				}
			}
			
		#endregion



		#region Lists To Arrays

			/// <summary>
			/// Get an object array of the ParameterUrlList
			/// </summary>
			/// <returns>Object array with the contents of ParameterUrlList</returns>
			public object[] GetUrlObjectArray()
			{
				// ReSharper disable once CoVariantArrayConversion
				return ParameterUrlList.ToArray();
			}

			/// <summary>
			/// Get an object array of the ParameterTypesList
			/// </summary>
			/// <returns>Object array with the contents of ParameterTypesList</returns>
			public object[] GetTypeObjectArray()
			{
				// ReSharper disable once CoVariantArrayConversion
				return ParameterTypesList.ToArray();
			}
		
			/// <summary>
			/// Get an object array of the ParameterNamesList
			/// </summary>
			/// <returns>Object array with the contents of ParameterNamesList</returns>
			public object[] GetNameObjectArray()
			{
				// ReSharper disable once CoVariantArrayConversion
				return ParameterNamesList.ToArray();
			}

			/// <summary>
			/// Get an object array of the ParameterNamesList
			/// </summary>
			/// <returns>Object array with the contents of ParameterNamesList</returns>
			public object[] GetValueObjectArray()
		{
			// ReSharper disable once CoVariantArrayConversion
			return ParameterValuesList.ToArray();
		}

		#endregion



	}
}
