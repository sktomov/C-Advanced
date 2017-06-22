using System;
using System.Text.RegularExpressions;

namespace _12.LittleJohn
{
	class LittleJohn
	{
		static void Main(string[] args)
		{
			string pattern = @"(>----->)|(>>----->)|(>>>----->>)";
			Regex regex = new Regex(pattern);
			int largeArrowscount = 0;
			int mediumArrowscount = 0;
			int smallArrowscount = 0;

			for (int i = 0; i < 4; i++)
			{
				var input = Console.ReadLine();
				if (regex.IsMatch(input))
				{
					foreach (Match match in regex.Matches(input))
					{
						if (match.Groups[1].Success)
						{
							smallArrowscount++;
						}
						if (match.Groups[2].Success)
						{
							mediumArrowscount++;
						}
						if (match.Groups[3].Success)
						{
							largeArrowscount++;
						}
					}
				}
			}

			int count = int.Parse(smallArrowscount.ToString() + mediumArrowscount.ToString() +
			                              largeArrowscount.ToString());
			string originalBinary = Convert.ToString(count, 2);
			string reversed = ReverseStringDirect(originalBinary);
			var binary = originalBinary + reversed;
			Console.WriteLine(Convert.ToInt32(binary, 2));
		}
		public static string ReverseStringDirect(string s)
		{
			char[] array = new char[s.Length];
			int forward = 0;
			for (int i = s.Length - 1; i >= 0; i--)
			{
				array[forward++] = s[i];
			}
			return new string(array);
		}
	}
}
