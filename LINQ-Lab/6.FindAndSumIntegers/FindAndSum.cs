using System;
using System.Linq;

namespace _6.FindAndSumIntegers
{
	class FindAndSum
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(' ');
			int number = 0;
			var result = input.Where(x => int.TryParse(x, out number));
			if (result.Count() != 0)
			{
				Console.WriteLine(result.Select(long.Parse).Sum());
			}
			else
			{
				Console.WriteLine("No match");
			}

		}
	}
}
