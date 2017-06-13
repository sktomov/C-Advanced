using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.ReplaceATag
{
	class ReplaceTag
	{
		static void Main()
		{
			string inputLine = Console.ReadLine();
			string patern = @"<a.{0,}?(href=?(['|""]?).+?\2).{0,}?>(.+?)<\/a>";
			Regex regex = new Regex(patern);
			var sb = new StringBuilder();
			while (inputLine != "end")
			{
				var replaced = regex.Replace(inputLine, m => $"[URL {m.Groups[1].Value}]{m.Groups[3].Value}[/URL]");
				sb.Append($"{replaced}{Environment.NewLine}");

				inputLine = Console.ReadLine();
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
