using System;
using System.Collections.Generic;

using Newtonsoft.Json;

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

		[JsonProperty(PropertyName = "ReferenceType")]
		public string ReferenceType { get; set; }

		[JsonProperty(PropertyName = "Version")]
		public string Version { get; set; }

		[JsonProperty(PropertyName = "Condition")]
		public string Condition { get; set; }

		[JsonProperty(PropertyName = "Convention")]
		public string Convention { get; set; }

		[JsonProperty(PropertyName = "Description")]
		public List<string> Description;

		[JsonProperty(PropertyName = "Examples")]
		public List<Example> ExampleList;

		[JsonProperty(PropertyName = "Tags")]
		public List<string> Tags { get; set; }

		[JsonProperty(PropertyName = "FromPlugin")]
		public string FromPlugin { get; set; }

		public void CleanFunctionDef()
		{
			if (String.IsNullOrEmpty(Alias))
				Alias = null;

			if (String.IsNullOrEmpty(Version))
				Version = null;

			if (String.IsNullOrEmpty(Condition))
				Condition = "False";
			else if (Condition == "False")
				Condition = null;

			if (String.IsNullOrEmpty(Convention))
				Convention = "E";

			if (String.IsNullOrEmpty(FromPlugin))
				FromPlugin = null;

			if (Parameters != null && Parameters.Count == 0)
				Parameters = null;

			if (ReturnType != null && ReturnType.Count == 0)
				ReturnType = null;

			if (ExampleList != null && ExampleList.Count == 0)
				ExampleList = null;

			if (Tags != null && Tags.Count == 0)
				Tags = null;
		}
	}

	/// <summary>
	/// A ParameterDef object that stores a URL hash string, a type, 
	/// and an indicator as to whether or not it is optional.
	/// </summary>
	public class ParameterDef
	{
		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "optional")]
		public string Optional { get; set; }

		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }
	}

	/// <summary>
	/// A Return Type object holds a URL hash string and a type
	/// </summary>
	public class ReturnTypeDef
	{
		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }
	}

	public class Example
	{
		[JsonProperty(PropertyName = "Example")]
		public List<string> Contents { get; set; }

		public Example()
		{
			Contents = new List<string>();
		}

		public Example(string example)
		{
			Contents = new List<string>(
						   example.Split(new[] { "\n" },
						   StringSplitOptions.RemoveEmptyEntries));
		}
	}
}
