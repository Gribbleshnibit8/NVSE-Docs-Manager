using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVSE_Docs_Manager
{
	public class Variables
	{

		public static List<Example> ExampleList { get; set; }

		/// <summary>
		/// Stores the current function prior to any changes
		/// </summary>
		public static FunctionDef currentEditingBackup { get; set;}

	}
}
