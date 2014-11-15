using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NVSE_Docs_Manager
{
	class WikiParser
	{

		WikiParserDisplay _windoWikiParserDisplay = null;

		private readonly string _rawFunction = "";

		public WikiParser(string toParse)
		{
			_rawFunction = toParse;
		}

		
		// the magic will happen in here, this will call all sub functions that will parse and return a function definition
		public FunctionDef GetFunction()
		{
			var function = new FunctionDef();

			// Strip the ending portion from the string. It's nothing but links that we don't need.
			var linkLess = RemoveLinks(_rawFunction);

			// Extract the upper function data from the rest of the data. This will get split up into the functionDef later
			var functionDefData = GetFunctionData(linkLess);

			// Remove the function data so we're left with only the extra information.
			linkLess = RemoveFunctionData(linkLess);

			// Split the rest of the data into a list of type Head, Data
			var infoSections = GetInfoSections(linkLess);

			ShowExtraData(functionDefData, infoSections);

			function = FillFunctionFields(function, functionDefData);


			return function;
		}


		/// <summary>
		/// Removes the "See Also" section and any other wiki links at the end of the string
		/// </summary>
		/// <param name="removeFrom">The string from which to remove parts</param>
		/// <returns>Returns a string with the parts removed</returns>
		private static string RemoveLinks(string removeFrom)
		{
			// removes the "See Also" section and anything below it
			var seeAlso = new Regex(@"(==[']*See Also[']*==.*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			var removed = seeAlso.Replace(removeFrom, "");

			// for pages without the "See Also" section, remove the block of additional links
			var linkBreaker = new Regex(@"^((\[\[)(\w*):(\w*)([\s\w\W]*?)(\]\]))$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			removed = linkBreaker.Replace(removed, "");
			return removed;
		}

		/// <summary>
		/// Separates the wiki defined function data and returns it in a List
		/// </summary>
		/// <param name="data">The string with the function data</param>
		/// <returns>List of split function data</returns>
		private static List<string> GetFunctionData(string data)
		{
			// get the function definition data out for further parsing
			var getFunction = new Regex(@"(\{\{.*\}\})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			var functionParts = new List<string>();
			foreach (string s in getFunction.Split(data)[1].Split(new string[] {"|", "}", "{", "}{"}, StringSplitOptions.RemoveEmptyEntries))
				functionParts.Add(s);

			// clean the list
			for (int index = 0; index < functionParts.Count; index++)
			{
				// remove excess spaces and newlines
				functionParts[index] = functionParts[index].Trim();

				// remove inline newlines except in summary and example
				if (functionParts[index].Contains("\n") && !functionParts[index].Contains("summary") || !functionParts[index].Contains("example"))
					functionParts[index] = functionParts[index].Replace("\n", "");

				// remove empty lines or lines that are only newlines
				if (String.IsNullOrEmpty(functionParts[index]) || functionParts[index] == "\n")
				{
					functionParts.RemoveAt(index);
					index--;
				}
			}

			return functionParts;
		}


		private static string RemoveFunctionData(string data)
		{
			var getFunction = new Regex(@"(\{\{.*\}\})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			return getFunction.Replace(data, "");
		}


		private static List<string> GetInfoSections(string data)
		{
			// gets each section of the page under any headings
			var dataGrabber = new Regex(@"([=]{2,5}[']*[\w\s]*[']*[=]{2,5})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			var s = dataGrabber.Split(data).ToList();

			// clean the list
			for (int index = 0; index < s.Count(); index++)
			{
				s[index] = s[index].Trim();

				if (String.IsNullOrEmpty(s[index]))
				{
					s.RemoveAt(index);
					index--;
				}
			}
			return s;
		}


		private static FunctionDef FillFunctionFields(FunctionDef function, List<string> functionDefData)
		{
			// Get the name of the function
			if (functionDefData.Find(s => s.ToLower().Contains("name")).Split('=').Length > 1)
				function.Name = functionDefData.Find(s => s.ToLower().Contains("name")).Split('=')[1].Trim();

			// Check if the function has an alias defined, and if so get it and add it to the function
			if (!string.IsNullOrEmpty(functionDefData.Find(s => s.ToLower().Contains("alias"))))
				if (functionDefData.Find(s => s.ToLower().Contains("alias")).Split('=').Length > 1)
					function.Alias = functionDefData.Find(s => s.ToLower().Contains("alias")).Split('=')[1].Trim();

			// Check if the function has a reference return type
			if (!String.IsNullOrEmpty(functionDefData.Find(s => s.ToLower().Contains("referencetype"))))
				if (functionDefData.Find(s => s.ToLower().Contains("referencetype")).Split('=').Length > 1)
					function.ReferenceType = functionDefData.Find(s => s.ToLower().Contains("referencetype")).Split('=')[1].Trim();

			// Check for origin and fill appropriate fields
			if (functionDefData.Find(s => s.ToLower().Contains("origin")).Split('=').Length > 1)
			{
				string t = functionDefData.Find(s => s.ToLower().Contains("origin")).Split('=')[1].Trim();
				function.Version = t;
				function.FromPlugin = t;
				if (function.Tags == null)
					function.Tags = new List<string>() {t};
				else
					function.Tags.Add(t);
			}

			// Get the first part of the description from the summary
			List<string> description = null;
			if (functionDefData.Find(s => s.ToLower().Contains("summary")).Split('=').Length > 1)
			{
				description = new List<string>
				{
					functionDefData.Find(s => s.ToLower().Contains("summary")).Split(new char[] {'='}, 2)[1].Trim()
				};
			}


			if (description != null)
				for (int index = 0; index < description.Count; index++)
				{
					description[index] = description[index].Replace("'''", "");
				}
			function.Description = description;

			// Get return type data
			if (functionDefData.Find(s => s.ToLower().Contains("returntype")).Split('=').Length > 1)
			{
				function.ReturnType = new List<ReturnTypeDef>() {new ReturnTypeDef()};
				function.ReturnType[0].Type = functionDefData.Find(s => s.ToLower().Contains("returntype")).Split('=')[1].Trim();

				if (Convert.ToBoolean(functionDefData.Find(s => s.ToLower().Contains("returnval"))))
				if (functionDefData.Find(s => s.ToLower().Contains("returnval")).Split('=').Length > 1)
					function.ReturnType[0].Value = functionDefData.Find(s => s.ToLower().Contains("returnval")).Split('=')[1].Trim();
			}
				

			// Get the parameters
			for (int index = 0; index < functionDefData.Count; index++)
			{
				if (functionDefData[index].ToLower().Contains("functionargument"))
				{
					int nextIndex = GetFunctionLength(functionDefData, index+1);
					
					var param = new ParameterDef();
					var typeString = new string[3] { "", ":", "" };

					// Gets the 
					for (int index2 = index + 1; index2 <= nextIndex; index2++)
					{
						if (functionDefData[index2].Length > functionDefData[index2].IndexOf("}", System.StringComparison.Ordinal) && functionDefData[index2].IndexOf("}", System.StringComparison.Ordinal) != -1)
							functionDefData[index2] = functionDefData[index2].Remove(functionDefData[index2].IndexOf("}", System.StringComparison.Ordinal));

						if (functionDefData[index2].ToLower().Contains("name"))
							if (functionDefData[index2].Split('=')[0].Trim().ToLower().Contains("name"))
								typeString[2] = functionDefData[index2].Split('=')[1].Trim();

						if (functionDefData[index2].ToLower().Contains("type"))
							if (functionDefData[index2].Split('=')[0].Trim().ToLower().Contains("type"))
								typeString[0] = functionDefData[index2].Split('=')[1].Trim();

						if (functionDefData[index2].ToLower().Contains("value"))
							if (functionDefData[index2].Split('=')[0].Trim().ToLower().Contains("value"))
								param.Value = functionDefData[index2].Split('=')[1].Trim();

						if (functionDefData[index2].ToLower().Contains("optional"))
							if (functionDefData[index2].Split('=')[0].Trim().ToLower().Contains("optional"))
								if (functionDefData[index2].Split('=')[1].Equals(" y"))
									param.Optional = "True";

					}
					param.Type = typeString[0] + typeString[1] + typeString[2];
					if (function.Parameters == null)
						function.Parameters = new List<ParameterDef>() {param};
					else
						function.Parameters.Add(param);
				}
			}


			return function;
		}


		private static int GetFunctionLength(List<string> data, int startIndex)
		{
			int i = 0;
			// startIndex is first occurrence of FunctionArgument
			for (i = startIndex; i < data.Count; i++)
			{
				if (data[i].ToLower().Contains("functionargument") || data[i].ToLower().Contains("example"))
					return i;
			}
			if (data.Count == i)
				return i - 1;
			return 0;
		}


		private void ShowExtraData(object functionDefData, object list)
		{
			if (_windoWikiParserDisplay == null || _windoWikiParserDisplay.IsDisposed)
			{
				_windoWikiParserDisplay = new WikiParserDisplay();
				_windoWikiParserDisplay.PopulateForm((List<string>) functionDefData);
				_windoWikiParserDisplay.PopulateForm((List<string>) list);
			}
			_windoWikiParserDisplay.Show();

			if (_windoWikiParserDisplay.Focused == false)
				_windoWikiParserDisplay.Focus();
		}


		/*private void holder()
		{
			string rawFunction = richTextBoxDescription.Text;
			

			

			// adds linebreak between double curly brackets
			var replaceCurlies = new Regex(@"}}{{", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			rawFunction = replaceCurlies.Replace(rawFunction, "}}\n{{");

			

			

			



			// clear all new
			

			// fill text boxes in form
			if (functionParts.Find(s => s.ToLower().Contains("name")).Split('=').Length > 1)
				textBoxName.Text = functionParts.Find(s => s.ToLower().Contains("name")).Split('=')[1].Trim();
			if (!string.IsNullOrEmpty(functionParts.Find(s => s.ToLower().Contains("alias"))))
				if (functionParts.Find(s => s.ToLower().Contains("alias")).Split('=').Length > 1)
					textBoxAlias.Text = functionParts.Find(s => s.ToLower().Contains("alias")).Split('=')[1].Trim();
			if (functionParts.Find(s => s.ToLower().Contains("origin")).Split('=').Length > 1)
			{
				string t = functionParts.Find(s => s.ToLower().Contains("origin")).Split('=')[1].Trim();
				textBoxVersion.Text = t;
				textBoxOrigin.Text = t;
				textBoxTags.Text = t;
			}

			// TODO: Remove triple apostrophe groups
			

			// TODO: write extra function to parse multiline examples into separate example lists
			//Variables.ExampleList = new List<Example>();
			//Variables.ExampleList.Add(new Example(functionParts.Find(s => s.ToLower().Contains("origin")).Split('=')[1].Trim()));



			
		}*/

	}
}
