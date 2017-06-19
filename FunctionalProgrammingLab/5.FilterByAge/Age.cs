using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FilterByAge
{
	class Age
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				var arr = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

			}
		}

		private int Operation(int number, Func<int, int> operation)
		{
			return operation(number);
		}
	}

}
