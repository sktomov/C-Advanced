using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ListOfPredicates
{
	class ListOfPredicates
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());

			var dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			Func<int, int, bool> filter = (x, d) => x % d == 0;
			CalculateAndPrint(n, dividers, filter);
		}

		private static void CalculateAndPrint(int n, int[] dividers, Func<int, int, bool> filter)
		{
			var result = new HashSet<int>();
			for (int j = 1; j <= n; j++)
			{
				
				bool isTrue = true;
				foreach (var divider in dividers)
				{
					
					if (!filter(j, divider))
					{
						isTrue = false;
						break;
					}
				}
				if (isTrue)
				{
					result.Add(j);
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
	}
}
