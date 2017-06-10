using System;

namespace _12.CharacterMultiplier
{
	class CharacterMultiplier
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(new[] {' ', '\n', '\r', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			var minElement = string.Empty;
			var maxElement = string.Empty;
			if (input[0].Length <= input[1].Length)
			{
				minElement = input[0];
				maxElement = input[1];
			}
			else
			{
				minElement = input[1];
				maxElement = input[0];
			}
			long sum = 0;
			for (int i = 0; i < maxElement.Length; i++)
			{
				if (i < minElement.Length)
				{
					sum += minElement[i] * maxElement[i];
				}
				else
				{
					sum += maxElement[i];
				}
			}
			Console.WriteLine(sum);
		}
	}
}
