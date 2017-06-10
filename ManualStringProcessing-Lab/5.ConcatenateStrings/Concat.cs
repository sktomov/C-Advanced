using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ConcatenateStrings
{
	class Concat
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var sb = new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				sb.Append(Console.ReadLine()).Append(" ");
			}
			Console.WriteLine(sb);
		}
	}
}
