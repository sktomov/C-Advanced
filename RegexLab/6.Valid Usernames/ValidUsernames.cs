using System;
using System.Text.RegularExpressions;

namespace _6.Valid_Usernames
{
	class ValidUsernames
	{
		static void Main()
		{
			var patern = @"^[\w-]{3,16}$";
			var regex = new Regex(patern);
			var inputLine = Console.ReadLine();
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
