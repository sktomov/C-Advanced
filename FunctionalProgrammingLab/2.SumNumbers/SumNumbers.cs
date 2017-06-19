using System;
using System.Linq;

namespace _2.SumNumbers
{
	class SumNumbers
	{
		static void Main()
		{
			Func<string, int> parser = n => int.Parse(n);
			var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(parser);
			Console.WriteLine(input.Count());
			Console.WriteLine(input.Sum());
		}
	}
}
