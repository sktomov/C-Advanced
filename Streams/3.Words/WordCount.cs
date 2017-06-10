using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _3.Words
{
	public class WordCount
	{
		public static void Main()
		{
			Console.Write("Give path for words file or tab 1 for static path: ");
			var path = Console.ReadLine();
			if (path.Equals("1"))
			{
				path = "../../words.txt";
			}
			var words = ReadFromFile(path);
			var keys = CreateSearchDictionary(words);
			//read text
			Console.Write("Give path for text file or tab 1 for static path: ");
			var textPath = Console.ReadLine();
			if (textPath.Equals("1"))
			{
				textPath = "../../text.txt";
			}
			var text = ReadFromFile(textPath);
			foreach (var key in keys.Keys.ToList())
			{
				var regex = new Regex($@"\b{key}\b");
				var matches = regex.Matches(text.ToLower());
				keys[key] = matches.Count;
			}
			WriteTextToFile(keys);
		}

		private static void WriteTextToFile(Dictionary<string, int> keys)
		{
			using (var writer = new StreamWriter(@"..\..\result.txt"))
			{
				foreach (var element in keys.OrderByDescending(b => b.Value))
				{
					writer.WriteLine($"{element.Key} - {element.Value}");
				}
			}
			Console.WriteLine("Success!");
		}

		private static string ReadFromFile(string path)
		{
			var sb = new StringBuilder();
			using (var reader = new StreamReader(path))
			{
				var inputLine = reader.ReadLine();
				while (inputLine != null)
				{
					sb.AppendLine(inputLine);
					inputLine = reader.ReadLine();
				}
			}
			return sb.ToString();
		}

		private static Dictionary<string, int> CreateSearchDictionary(string words)
		{
			var keys = words.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			var dict = new Dictionary<string, int>();
			foreach (var key in keys)
			{
				if (!dict.ContainsKey(key))
				{
					dict[key] = 0;
				}
			}
			return dict;
		}
	}
}