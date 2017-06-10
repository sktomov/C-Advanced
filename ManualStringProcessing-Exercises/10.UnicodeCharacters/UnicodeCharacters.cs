using System;

namespace _10.UnicodeCharacters
{
	class UnicodeCharacters
	{
		static void Main()
		{
			var input = Console.ReadLine();
			for (int i = 0; i < input.Length; i++)
			{
				var unicode = ((int) input[i]).ToString("x4");
				Console.Write($"\\u{unicode}");
			}
		}
	}
}
