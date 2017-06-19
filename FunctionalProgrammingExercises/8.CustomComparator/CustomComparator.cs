using System;
using System.Linq;

namespace _8.CustomComparator
{
	class CustomComparator
	{
		static void Main(string[] args)
		{
			var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			Array.Sort(arr, (x, y) =>
			{
				if (x % 2 == 0 && y % 2 != 0)
				{
					return -1;
				}
				if (x % 2 != 0 && y % 2 == 0)
				{
					return 1;
				}
				if (x > y)
				{
					return 1;
				}
				if (x < y)
				{
					return -1;
				}
				return 0;
			});
			Console.WriteLine(string.Join(" ", arr));
		}
	}
}
a