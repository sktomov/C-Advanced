using System;
using System.Text.RegularExpressions;

namespace Non_Digit_Count
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			var rgx  = new Regex(@"\D");
			Console.WriteLine($"Non-digits: {rgx.Matches(text).Count}");
		}
	}
}
