using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Lego
{
	class Lego
	{
		static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var firstMatrix = new int[n][];
			var reversedMatrix = new int[n][];
			FillMatricies(n, firstMatrix, reversedMatrix);
			var squareLength = firstMatrix[0].Length + reversedMatrix[0].Length;
			bool isSquare = true;
			for (int rowIndex = 0; rowIndex < n; rowIndex++)
			{
				var rowLenght = firstMatrix[rowIndex].Length + reversedMatrix[rowIndex].Length;
				if (squareLength != rowLenght)
				{
					isSquare = false;
				}
			}
			if (isSquare)
			{
				var resultMatrix = new int[n][];
				for (int row = 0; row < n; row++)
				{
					resultMatrix[row] = new int[squareLength];
					resultMatrix[row] = firstMatrix[row].Concat(reversedMatrix[row]).ToArray();
					Console.WriteLine($"[{string.Join(", ", resultMatrix[row])}]");
				}
			}
			else
			{
				var cellCount = 0;
				for (int rowIndex = 0; rowIndex < n; rowIndex++)
				{
					cellCount += firstMatrix[rowIndex].Length + reversedMatrix[rowIndex].Length;
				}
				Console.WriteLine($"The total number of cells is: {cellCount}");
			}

		}

		private static void FillMatricies(int n, int[][] firstMatrix, int[][] reversedMatrix)
		{
			for (int rowIndex = 0; rowIndex < n; rowIndex++)
			{
				firstMatrix[rowIndex] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToArray();
			}
			for (int rowIndex = 0; rowIndex < n; rowIndex++)
			{
				reversedMatrix[rowIndex] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).Reverse().ToArray();
			}
		}
	}
}
