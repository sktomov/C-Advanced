using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.AppliedArithmetics
{
	class AppliedArithmetics
	{
		static void Main()
		{
			var arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
			var cmd = Console.ReadLine();
			while (cmd != "end")
			{
				switch (cmd)
				{
					case "add":
						arr = Calculate(arr, n => n + 1);
						break;
					case "multiply":
						arr = Calculate(arr, n => n * 2);
						break;
					case "subtract":
						arr = Calculate(arr, n => n - 1);
						break;
					case "print":
						Console.WriteLine(string.Join(" ", arr));
						break;
					default:
						Console.WriteLine("Invalid!");
						break;
				}
				cmd = Console.ReadLine();
			}
		}

		public static IEnumerable<int> Calculate(IEnumerable<int> arr, Func<int, int> function)
		{
			return arr.Select(x => function(x));
		}
	}
}
