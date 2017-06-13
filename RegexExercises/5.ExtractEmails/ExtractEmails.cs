using System;
using System.Text.RegularExpressions;

namespace _5.ExtractEmails
{
	class ExtractEmails
	{
		static void Main(string[] args)
		{
			string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*@[a-zA-z][\.\-a-zA-z]+\.[a-z]*\b)";
			Regex regex = new Regex(pattern);
			var text = Console.ReadLine();
			foreach (var match in regex.Matches(text))
			{
				Console.WriteLine(match);
			}
		}
	}
}
