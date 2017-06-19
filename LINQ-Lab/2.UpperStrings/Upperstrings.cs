using System;
using System.Linq;

namespace _2.UpperStrings
{
	class Upperstrings
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
			input.Select(w => w.ToUpper()).ToList().ForEach(s => Console.Write(s + " "));
		}
	}
}
