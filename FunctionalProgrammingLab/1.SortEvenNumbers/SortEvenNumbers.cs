using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
	class SortEvenNumbers
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries);
			var result = input.Select(int.Parse).Where(n => n % 2 == 0).OrderBy(x => x);
			Console.WriteLine(string.Join(", ", result));
			
		}
	}
}
