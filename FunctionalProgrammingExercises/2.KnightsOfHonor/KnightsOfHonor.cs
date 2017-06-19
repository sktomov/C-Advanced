using System;

namespace _2.KnightsOfHonor
{
	class KnightsOfHonor
	{
		static void Main()
		{
			string[] input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			Action<string> print = x => Console.WriteLine("Sir " + x);
			foreach (var element in input)
			{
				print.Invoke(element);
			}
		}
	}
}
