using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.PredicateForNames
{
	class PredicateForNames
	{
		static void Main()
		{
			int lenght = int.Parse(Console.ReadLine());
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			
			Predicate<int> isValid = x => x <= lenght;
			foreach (var s in input)
			{
				if (isValid(s.Length))
				{
					Console.WriteLine(s);
				}
			}
		}
	}
}
