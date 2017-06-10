using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sum_big_numbers
{
	class SumBigNumbers
	{
		static void Main(string[] args)
		{
			string line1 = Console.ReadLine().Trim();
			string line2 = Console.ReadLine().Trim();
			int maxLen = Math.Max(line1.Length, line2.Length);
			line1 = line1.PadLeft(maxLen + 1, '0');
			line2 = line2.PadLeft(maxLen + 1, '0');
			int[] arr1 = line1.Select(x => int.Parse(x.ToString())).ToArray();
			int[] arr2 = line2.Select(x => int.Parse(x.ToString())).ToArray();
			int[] sum = new int[arr1.Length];
			int last = 0;
			for (int i = sum.Length - 1; i >= 0; i--)
			{
				int total = arr1[i] + arr2[i] + last;
				sum[i] = total % 10;
				if (total > 9)
				{
					last = 1;
				}
				else
				{
					last = 0;
				}
			}
			Console.WriteLine(string.Join("", sum.SkipWhile(c => c == 0)));
		}
	}
}
