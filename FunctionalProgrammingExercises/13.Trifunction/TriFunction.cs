using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Trifunction
{
	class TriFunction
	{
		static void Main()
		{
			var charactersSum = int.Parse(Console.ReadLine());

			var arrOfNames = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			Func<string, int, bool> isValid = (name, sum) => name.ToCharArray().Select(c => (int) c).Sum() >= sum;

			Func<string[], int, Func<string, int, bool>, string> firstValid = (arr, num, func) => arr
				.FirstOrDefault(str => func(str, num));

			var result = firstValid(arrOfNames, charactersSum, isValid);
			Console.WriteLine(result);
		}
	}
}
