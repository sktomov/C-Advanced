using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SpecialWords
{
	class Words
	{
		static void Main()
		{
			var separators = new char[] {'(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' '};
			var words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
			var text = Console.ReadLine();
			var dict = new Dictionary<string, int>();

			foreach (var word in words)
			{
				var index = text.IndexOf(word);
				if (!dict.ContainsKey(word))
				{
					dict[word] = 0;
				}
				while (index != -1)
				{
					dict[word]++;
					index = text.IndexOf(word, index +1);
				}
			}
			foreach (var kvp in dict)
			{
				Console.WriteLine($"{kvp.Key} - {kvp.Value}");
			}
		}
	}
}
