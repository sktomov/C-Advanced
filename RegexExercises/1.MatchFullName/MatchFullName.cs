
using System;
using System.Text.RegularExpressions;

namespace _1.MatchFullName
{
	class MatchFullName
	{
		static void Main()
		{
			string inputLine = Console.ReadLine();
			string patern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
			Regex regex = new Regex(patern);
			while (inputLine !="end")
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
