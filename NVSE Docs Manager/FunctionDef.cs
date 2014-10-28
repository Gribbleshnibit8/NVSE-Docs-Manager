using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft;

namespace NVSE_Docs_Manager
{
	// TODO
	// Need a list to hold all ParameterDef and Return Type type fields

	[JsonObject(MemberSerialization = MemberSerialization.OptOut)]
	public class FunctionDef
	{

		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set;}

		[JsonProperty(PropertyName = "Alias")]
		public string Alias { get; set; }

		[JsonProperty(PropertyName = "Parameters")]
		public List<ParameterDef> Parameters;

		[JsonProperty(PropertyName = "ReturnType")]
		public List<ReturnTypeDef> ReturnType;

		[JsonProperty(PropertyName = "Version")]
		public string Version { get; set; }

		[JsonProperty(PropertyName = "Condition")]
		public string Condition { get; set; }

		[JsonProperty(PropertyName = "Convention")]
		public string Convention { get; set; }

		[JsonProperty(PropertyName = "Description")]
		public List<string> Description;

		[JsonProperty(PropertyName = "Examples")]
		public List<Examples> ExampleList;

		[JsonProperty(PropertyName = "Tags")]
		public List<string> Tags { get; set; }

		[JsonProperty(PropertyName = "FromPlugin")]
		public string FromPlugin { get; set; }

		[JsonProperty(PropertyName = "Category")]
		public string Category { get; set; }
	}

	/// <summary>
	/// A ParameterDef object that stores a URL hash string, a type, 
	/// and an indicator as to whether or not it is optional.
	/// </summary>
	public class ParameterDef
	{
		public string url { get; set; }
		public string type { get; set; }
		public string optional { get; set; }
	}

	/// <summary>
	/// A Return Type object holds a URL hash string and a type
	/// </summary>
	public class ReturnTypeDef
	{
		public string url { get; set; }
		public string type { get; set; }
	}

	public class Examples
	{
		public List<string> Example { get; set; }
	}
}
