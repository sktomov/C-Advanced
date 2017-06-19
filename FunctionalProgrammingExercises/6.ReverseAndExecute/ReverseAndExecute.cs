using System;
using System.Linq;

namespace _6.ReverseAndExecute
{
	class ReverseAndExecute
	{
		static void Main()
		{
			int[] arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int n = int.Parse(Console.ReadLine());
			Predicate<int> isDivisible = x => x % n != 0;
			for (int i = arr.Length - 1; i >= 0; i--)
			{
				if (isDivisible(arr[i]))
				{
					Console.Write($"{arr[i]} ");
				}
			}
		}
	}
}
