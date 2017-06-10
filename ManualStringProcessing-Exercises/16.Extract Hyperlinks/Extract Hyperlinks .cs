using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16.Extract_Hyperlinks
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var sb = new StringBuilder();
			while (input !="END")
			{
				sb.Append(input);
				sb.Append("\n");

				input = Console.ReadLine();
			}
			string pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""""()]*?.*?)(?:href([\s\n]*)?=(?:['""""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""""()0-9]*.*?)?(?:\>)";
			var regex = new Regex(pattern);
			foreach (Match match in regex.Matches(sb.ToString()))
			{
				if (match.Groups[2].Value != "fake")
				{
					Console.WriteLine(match.Groups[2].Value);
				}
			}
		}
	}
}
