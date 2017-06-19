using System;
using System.Linq;

namespace _4.AddVat
{
	class Vat
	{
		static void Main()
		{
			Console.ReadLine()
				.Split(new string[] { ", " },
					StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.Select(n => n * 1.2)
				.ToList()
				.ForEach(n => Console.WriteLine($"{n:n2}"));
		}
	}
}
