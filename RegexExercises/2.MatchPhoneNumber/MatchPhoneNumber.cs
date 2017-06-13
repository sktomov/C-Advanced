using System;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
	class MatchPhoneNumber
	{
		static void Main()
		{
			string inputLine = Console.ReadLine();
			string patern = @"^\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
			Regex regex = new Regex(patern);
			while (inputLine != "end")
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
