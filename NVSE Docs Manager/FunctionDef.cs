using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace NVSE_Docs_Manager
{

	// TODO
	// Need a list to hold all Parameter and Return Type type fields

	public class FunctionList
	{
		public string[] Function { get; set; }
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class FunctionDef
	{

		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set;}

		[JsonProperty(PropertyName = "Alias")]
		public string Alias { get; set; }

		[JsonProperty(PropertyName = "Parameters")]
		public List<Parameter> Parameters;

		[JsonProperty(PropertyName = "ReturnType")]
		public ReturnType ReturnType;

		[JsonProperty(PropertyName = "Version")]
		public string Version { get; set; }

		[JsonProperty(PropertyName = "Condition")]
		public string Condition { get; set; }

		[JsonProperty(PropertyName = "Convention")]
		public string Convention { get; set; }

		[JsonProperty(PropertyName = "Description")]
		public List<string> Description;

		[JsonProperty(PropertyName = "ExampleList")]
		public List<Examples> ExampleList;

		[JsonProperty(PropertyName = "Tags")]
		public List<string> Tags { get; set; }

		[JsonProperty(PropertyName = "FromPlugin")]
		public string FromPlugin { get; set; }

		[JsonProperty(PropertyName = "Category")]
		public string Category { get; set; }

		public FunctionDef()
		{
			Parameters = new List<Parameter>();
			ReturnType = new ReturnType();
			Description = new List<string>();
			ExampleList = new List<Examples>();
			Tags = new List<string>();
		}

		

		public override string ToString()
		{
			string s = "";

			s += "\"Name\": " + Name;


			return s;
		}

	}

	public class Parameter
	{
		public string url { get; set; }
		public string type { get; set; }
		public string optional { get; set; }
	}

	public class ReturnType
	{
		public string url { get; set; }
		public string type { get; set; }
	}

	public class Examples
	{
		public string[] Example { get; set; }
	}
}
