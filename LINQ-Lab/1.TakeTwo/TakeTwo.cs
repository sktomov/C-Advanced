using System;
using System.Linq;

namespace _1.TakeTwo
{
	class TakeTwo
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			input.Select(int.Parse).Distinct().Where(n => n >= 10 && n <= 20).Take(2).ToList().ForEach(x => Console.Write(x + " "));
		}
	}
}
