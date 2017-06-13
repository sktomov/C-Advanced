using System;
using System.Text.RegularExpressions;

namespace _3.SeriesOfLetters
{
	class SeriesOfLetters
	{
		static void Main()
		{
			var input = Console.ReadLine();
			Regex regex = new Regex(@"([a-z])\1+");
			input = regex.Replace(input, "$1");
			Console.WriteLine(input);
		}
	}
}
