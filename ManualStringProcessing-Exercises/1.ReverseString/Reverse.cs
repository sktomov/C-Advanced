using System;

namespace _1.ReverseString
{
	class Reverse
	{
		static void Main()
		{
			var input = Console.ReadLine().ToCharArray();
			Array.Reverse(input);
			Console.WriteLine(input);
		}
	}
}
