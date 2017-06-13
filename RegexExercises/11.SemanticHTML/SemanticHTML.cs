using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.SemanticHTML
{
	class SemanticHTML
	{
		static void Main(string[] args)
		{
			string div = @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>";
			string closedDiv = @"<\/div>\s*<!--\s*(.*?)\s*-->";
			string inputLine = Console.ReadLine();

			while (inputLine != "END")
			{
				Match open = Regex.Match(inputLine, div);
				Match closed = Regex.Match(inputLine, closedDiv);
				if (open.Success)
				{
					inputLine = Regex.Replace(inputLine, div, @"$3 $2 $4").Trim();
					inputLine = "<" + Regex.Replace(inputLine, @"\s+", " ") +">";
				}
				else if (closed.Success)
				{
					inputLine = "</" + closed.Groups[1] + ">";
				}
				Console.WriteLine(inputLine);
				inputLine = Console.ReadLine();
			}

		}
	}
}
