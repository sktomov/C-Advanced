using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EvenOrOdd
{
	class EvenOrOdd
	{
		static void Main()
		{
			int[] arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int start = arr[0];
			int end = arr[1];
			string cmd = Console.ReadLine();
			Predicate<int> even = x => x % 2 == 0;
			HashSet<int> result = new HashSet<int>();
			for (int i = start; i <= end; i++)
			{
				if (cmd == "even")
				{
					if (even(i))
					{
						result.Add(i);
					}
				}
				else
				{
					if (!even(i))
					{
						result.Add(i);
					}
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
	}
}
