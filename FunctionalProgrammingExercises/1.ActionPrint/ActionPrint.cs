using System;

namespace _1.ActionPrint
{
	class ActionPrint
	{
		static void Main()
		{
			Action<string> print = x => Console.WriteLine(x);
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var element in input)
			{
				print.Invoke(element);
			}
		}
	}
}
