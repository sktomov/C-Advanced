using System;
using System.Linq;
using System.Numerics;


namespace _4.Base10
{
	class Base10
	{
		static void Main()
		{
			BigInteger[] read = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
			BigInteger baseN = read[0];
			BigInteger number = read[1];
			BigInteger reminder;
			string result = string.Empty;
			if (baseN >= 2 && baseN <= 10)
			{
				while (number > 0)
				{
					reminder = number % baseN;
					number /= baseN;
					result = reminder.ToString() + result;

				}
				Console.WriteLine(result);
			}
			else
				Console.WriteLine(0);
		}
	}
}
