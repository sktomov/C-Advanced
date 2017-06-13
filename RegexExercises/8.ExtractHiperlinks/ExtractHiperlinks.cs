using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8.ExtractHiperlinks
{
	class ExtractHiperlinks
	{
		static void Main(string[] args)
		{
			var text = Console.ReadLine();
			var sb = new StringBuilder();
			while (text!="END")
			{
				sb.Append(text);
				text = Console.ReadLine();
			}
			var patern = @"<a[\s\S]*?\s+href\s*={0,1}\s*([""""'])?([\s\S]*?)(?:>|class|\1)[\s\S]*?<\/a>";
			var regex = new Regex(patern);
			foreach (Match match in regex.Matches(sb.ToString()))
			{
				Console.WriteLine(match.Groups[2].Value);
			}
		}
	}
}
