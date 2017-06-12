using System;
using System.Text.RegularExpressions;

namespace _4.ExtractIntegerNumbers
{
	class ExtractIntegerNumbers
	{
		static void Main()
		{
			var pattern = @"\d+";
			Regex regex = new Regex(pattern);
			string text = Console.ReadLine();
			if (regex.IsMatch(text))
			{
				foreach (Match match in regex.Matches(text))
				{
					Console.WriteLine(match);
				}
			}
		}
	}
}
