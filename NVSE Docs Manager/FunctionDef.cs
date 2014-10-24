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
		public List<ReturnType> ReturnType;

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

		public FunctionDef()
		{
			Name = "";
			Alias = "";
			Version = "";
			Condition = "";
			Convention = "";
			FromPlugin = "";
			Category = "";
			Parameters = new List<Parameter>();
			ReturnType = new List<ReturnType>();
			Description = new List<string>();
			ExampleList = new List<Examples>();
			Tags = new List<string>();
		}

		public bool Equals(FunctionDef obj)
		{
			if (obj == null)
				return false;

			if (this.Name.Equals(obj.Name))
				if (this.Alias.Equals(obj.Alias))
					if (this.Version.Equals(obj.Version))
						if (this.Convention.Equals(obj.Convention))
							if (this.Condition.Equals(obj.Condition))
								if (this.Tags.Equals(obj.Tags))
									if (this.FromPlugin.Equals(obj.FromPlugin))
										if (this.Category.Equals(obj.Category))
											if (this.Parameters.Equals(obj.Parameters))
												if (this.ReturnType.Equals(obj.ReturnType))
													return true;
			return false;
		}

	}

	/// <summary>
	/// A parameter object that stores a URL hash string, a type, 
	/// and an indicator as to whether or not it is optional.
	/// </summary>
	public class Parameter
	{
		public string url { get; set; }
		public string type { get; set; }
		public string optional { get; set; }

		public Parameter()
		{
			url = "";
			type = "";
			optional = "";
		}

		public bool Equals(Parameter obj)
		{
			if (this.url.Equals(obj.url))
				if (this.type.Equals(obj.type))
					if (this.optional.Equals(obj.optional))
						return true;
			return false;
		}
	}

	/// <summary>
	/// A Return Type object holds a URL hash string and a type
	/// </summary>
	public class ReturnType
	{
		public string url { get; set; }
		public string type { get; set; }

		public ReturnType()
		{
			url = "";
			type = "";
		}

		public bool Equals(ReturnType obj)
		{
			if (this.url.Equals(obj.url))
				if (this.type.Equals(obj.type))
					return true;
			return false;
		}
	}

	public class Examples
	{
		public List<string> Example { get; set; }
	}
}
