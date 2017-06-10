using System;
using System.Collections.Generic;

namespace _11.Palindromes
{
	class Palindromes
	{
		static void Main()
		{
			//Use spaces, commas, dots, question marks and exclamation marks as word delimiters
			var words = Console.ReadLine().Split(new[] {' ', ',', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);
			var set = new SortedSet<string>();
			foreach (var word in words)
			{
				if (IsPalindrome(word)|| word.Length == 1)
				{
					set.Add(word);
				}
			}
			Console.WriteLine($"[{string.Join(", ", set)}]");

		}

		private static bool IsPalindrome(string word)
		{
			bool isPalindrome = false;
			for (int i = 0; i < word.Length/2; i++)
			{
				if (word[i] == word[word.Length - i - 1])
				{
					isPalindrome = true;
				}
				else
				{
					isPalindrome = false;
					break;
				}
			}
			return isPalindrome;
		}
	}
}
