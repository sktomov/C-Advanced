using System;
using System.Linq;

namespace _5.MinEvenNumber
{
	class MinEvenNumber
	{
		static void Main()
		{
			var doubles = Console.ReadLine().Split(' ').Select(double.Parse);
			var result = doubles.Where(n => n % 2 == 0).ToList();
			if (result.Count != 0)
			{
				Console.WriteLine($"{result.Min():f2}");
			}
			else
			{
				Console.WriteLine("No match");
			}
		}
	}
}
