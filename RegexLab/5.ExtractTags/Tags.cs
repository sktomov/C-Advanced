using System;
using System.Text.RegularExpressions;

namespace _5.ExtractTags
{
	class Tags
	{
		static void Main()
		{
			var inputLine = Console.ReadLine();
			var regex = new Regex(@"<.+?>");
			while (inputLine != "END")
			{
				if (regex.IsMatch(inputLine))
				{
					foreach (Match match in regex.Matches(inputLine))
					{
						Console.WriteLine(match);
					}
				}

				inputLine = Console.ReadLine();
			}
			
		}
	}
}
