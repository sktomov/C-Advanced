using System;
using System.Linq;

namespace _4.AverageOfDoubles
{
	class Average
	{
		static void Main()
		{
			var doubles = Console.ReadLine().Split(' ').Select(double.Parse);
			Console.WriteLine($"{doubles.Average():f2}");
		}
	}
}
