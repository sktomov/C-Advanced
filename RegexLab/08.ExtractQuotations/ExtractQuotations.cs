using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractQuotations
{
	class ExtractQuotations
	{
		static void Main()
		{
			string text = Console.ReadLine();
			var patern = @"('.+?'|"".+?"")";
			Regex regex = new Regex(patern);
			if (regex.IsMatch(text))
			{
				foreach (Match match in regex.Matches(text))
				{
					Console.WriteLine(match.ToString().Substring(1, match.Length -2));
				}
			}
		}
	}
}
