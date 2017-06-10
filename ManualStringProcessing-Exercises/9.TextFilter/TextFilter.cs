using System;

namespace _9.TextFilter
{
	class TextFilter
	{
		static void Main()
		{
			var banWords = Console.ReadLine().Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
			var text = Console.ReadLine();
			foreach (var word in banWords)
			{
				text = text.Replace(word, new string('*', word.Length));
			}
			Console.WriteLine(text);
		}
	}
}
