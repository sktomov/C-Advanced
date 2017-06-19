using System;
using System.Linq;

namespace _3.FirstName
{
	class FirstName
	{
		static void Main()
		{
			var names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			var letters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(x => x);
			foreach (var letter in letters)
			{
				var result = names.Where(n => n.ToLower().StartsWith(letter.ToLower())).FirstOrDefault();
				if (result != null)
				{
					Console.WriteLine(result);
					return;
				}
			}
			Console.WriteLine("No match");
		}
	}
}
