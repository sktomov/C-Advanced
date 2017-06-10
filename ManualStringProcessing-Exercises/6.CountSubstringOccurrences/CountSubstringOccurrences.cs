using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CountSubstringOccurrences
{
	class CountSubstringOccurrences
	{
		static void Main()
		{
			var text = Console.ReadLine();
			var searchString = Console.ReadLine();
			var count = 0;
			var index = text.IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
			while (index != -1)
			{
				count++;
				index = text.IndexOf(searchString, index+1, StringComparison.OrdinalIgnoreCase);
			}
			Console.WriteLine(count);
		}
	}
}
