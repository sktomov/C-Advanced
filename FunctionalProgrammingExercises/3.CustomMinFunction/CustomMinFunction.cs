using System;
using System.Linq;

namespace _3.CustomMinFunction
{
	class CustomMinFunction
	{
		static void Main()
		{
			int[] arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			Func<int[], int> min = x => x.Min();
			Action<int> result = m => Console.WriteLine(m);
			var minNumber  = min.Invoke(arr);
			result.Invoke(minNumber);
		}
	}
}
