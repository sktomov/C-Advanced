using System;
using System.Linq;

namespace _7.BoundedNumbers
{
	class BoundedNumbers
	{
		static void Main(string[] args)
		{
			var boundaries = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
		
			var numbers = Console.ReadLine().Split(' ').Select(int.Parse).Where(n => n >= boundaries[0] && n <= boundaries[1] || n>= boundaries[1] && n <= boundaries[0])
				.ToList();
			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}
