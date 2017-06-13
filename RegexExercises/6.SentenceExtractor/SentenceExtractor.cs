using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _6.SentenceExtractor
{
	class SentenceExtractor
	{
		static void Main()
		{
			string key = Console.ReadLine();
			string text = Console.ReadLine();
			string patern = $"[^.!?]+?\\b{key}\\b[^.!?]+?[!?.]";
			Regex regex = new Regex(patern, RegexOptions.IgnoreCase);
			var sb = new StringBuilder();
			foreach (Match match in regex.Matches(text))
			{
				sb.Append($"{match}{Environment.NewLine}");
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
