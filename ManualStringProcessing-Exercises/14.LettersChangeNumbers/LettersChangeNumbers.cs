using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace _14.LettersChangeNumbers
{
	class LettersChangeNumbers
	{
		static void Main()
		{
			var alphabet = new Dictionary<char, int>(){{'a', 1}, {'b', 2}, {'c', 3}, { 'd', 4 }, { 'e', 5 }, { 'f', 6 }, { 'g', 7 }, { 'h', 8 }, { 'i', 9 }, { 'j', 10 }, { 'k', 11 }, { 'l', 12 }, { 'm', 13 }, { 'n', 14 }, { 'o', 15 }, { 'p', 16 }, { 'q', 17 }, { 'r', 18 }, { 's', 19 }, { 't', 20 }, { 'u', 21 }, { 'v', 22 }, { 'w', 23 }, { 'x', 24 }, { 'y', 25 }, { 'z', 26 }};
			var words = Console.ReadLine().Split(new[] {' ', '\r', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
			double sum = 0;
			foreach (var word in words)
			{
				sum += CalculateSum(word, alphabet);
			}
			Console.WriteLine($"{sum:f2}");
		}

		private static double CalculateSum(string word, Dictionary<char, int> alphabet)
		{
			double sum = 0;
			var firstLetter = word[0];
			var lastLetter = word[word.Length - 1];
			var number = double.Parse(word.Substring(1, word.Length - 2));
			if (Char.IsUpper(firstLetter))
			{
				sum = number / alphabet[Char.ToLower(firstLetter)];
			}
			else if (Char.IsLower(firstLetter))
			{
				sum = number* alphabet[Char.ToLower(firstLetter)];
			}

			if (Char.IsUpper(lastLetter))
			{
				sum = sum - alphabet[Char.ToLower(lastLetter)];
			}
			else if (Char.IsLower(lastLetter))
			{
				sum = sum + alphabet[Char.ToLower(lastLetter)];
			}
			return sum;
		}
	}
}
