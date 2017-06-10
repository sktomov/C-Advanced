using System;
using System.Linq;

namespace _13.MagicExchangeableWords
{
	class MagicExchangeableWords
	{
		static void Main()
		{
			string[] words = Console.ReadLine().Split();
			string firstWord = words[0];
			string secondWord = words[1];
			int len = Math.Min(firstWord.Length, secondWord.Length);
			int firstLen = firstWord.ToCharArray().Distinct().Count();
			int secondLen = secondWord.ToCharArray().Distinct().Count();
			if (firstLen != secondLen)
			{
				Console.WriteLine("false");
			}
			else
			{
				for (int i = 1; i < len; i++)
				{
					bool chek1 = firstWord[i] == firstWord[i - 1];
					bool chek2 = secondWord[i] == secondWord[i - 1];
					if (chek2 != chek1)
					{
						Console.WriteLine("false");
						return;
					}
				}
				Console.WriteLine("true");
			}
		}
	}
}
