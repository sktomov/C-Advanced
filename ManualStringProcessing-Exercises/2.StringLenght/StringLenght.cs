using System;

namespace _2.StringLenght
{
	class StringLenght
	{
		static void Main()
		{
			var text = Console.ReadLine();
			var result = string.Empty;
			if (text.Length <= 20)
			{
				result = text.PadRight(20, '*');
			}
			else
			{
				result = text.Substring(0, 20);
			}
			
			Console.WriteLine(result);
		}
	}
}
