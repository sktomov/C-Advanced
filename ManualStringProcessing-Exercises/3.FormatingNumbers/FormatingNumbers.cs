using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FormatingNumbers
{
	class FormatingNumbers
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(new[] {' ', '\r', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
			int a = int.Parse(input[0]);
			double b = double.Parse(input[1]);
			double c = double.Parse(input[2]);
			var hex = string.Format($"{a:X}").PadRight(10, ' ');
			var binary = Convert.ToString(a, 2);
			if (binary.Length >= 10)
			{
				binary = binary.Substring(0, 10);
			}
			else
			{
				binary = binary.PadLeft(10, '0');
			}
			var bPaded = string.Format($"{b:f2}").PadLeft(10, ' ');
			var cPaded = string.Format($"{c:f3}").PadRight(10, ' ');
			Console.WriteLine($"|{hex}|{binary}|{bPaded}|{cPaded}|");

		}
	}
}
