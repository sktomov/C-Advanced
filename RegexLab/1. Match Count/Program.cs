using System;
using System.Text.RegularExpressions;

namespace _1.Match_Count
{
	class Program
	{
		static void Main()
		{
			Regex rexeg = new Regex(Console.ReadLine());
			string text = Console.ReadLine();
			Console.WriteLine(rexeg.Matches(text).Count);
		}
	}
}
