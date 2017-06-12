using System;
using System.Text.RegularExpressions;

namespace _2.VowelsCount
{
	class VowelsCount
	{
		static void Main()
		{
			var patern = @"[AEIOUYaeiouy]";
			Regex reg = new Regex(patern);
			Console.WriteLine($"Vowels: {reg.Matches(Console.ReadLine()).Count}");
		}
	}
}
