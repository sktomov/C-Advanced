using System;
using System.Text.RegularExpressions;

namespace _7.ValidTime
{
	class ValidTime
	{
		static void Main(string[] args)
		{
			string patern = @"^[0-1][0-9]:([0-5][0-9]):([0-5][0-9]) (AM|PM)$";
			Regex regex = new Regex(patern);
			string inputLine = Console.ReadLine();
			while (inputLine !="END")
			{
				if (regex.IsMatch(inputLine))
				{
					Console.WriteLine("valid");
				}
				else
				{
					Console.WriteLine("invalid");
				}
				inputLine = Console.ReadLine();
			}
		}
	}
}
