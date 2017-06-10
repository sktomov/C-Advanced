using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MaxSum
{
	class MaxSum
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			var matrix = new int[input[0]][];
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				matrix[rowIndex] = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
					.ToArray();
			}
			var maxSum = 0;
			var matrixRowIndex = 0;
			var matrixColIndex = 0;
			for (int rowIndex = 0; rowIndex <= matrix.Length - 3; rowIndex++)
			{
				for (int col = 0; col <= matrix[rowIndex].Length - 3; col++)
				{
					var currentSum = matrix[rowIndex][col] + matrix[rowIndex][col + 1] + matrix[rowIndex][col + 2] +
					                 matrix[rowIndex + 1][col] + matrix[rowIndex + 1][col + 1] + matrix[rowIndex + 1][col + 2] +
					                 matrix[rowIndex + 2][col] + matrix[rowIndex + 2][col + 1] + matrix[rowIndex + 2][col + 2];
					if (currentSum > maxSum)
					{
						maxSum = currentSum;
						matrixRowIndex = rowIndex;
						matrixColIndex = col;
					}

				}
			}
			Console.WriteLine($"Sum = {maxSum}");
			Console.WriteLine($"{matrix[matrixRowIndex][matrixColIndex]} {matrix[matrixRowIndex][matrixColIndex +1]} {matrix[matrixRowIndex][matrixColIndex+2]}");
			Console.WriteLine($"{matrix[matrixRowIndex+1][matrixColIndex]} {matrix[matrixRowIndex+1][matrixColIndex + 1]} {matrix[matrixRowIndex+1][matrixColIndex + 2]}");
			Console.WriteLine($"{matrix[matrixRowIndex+2][matrixColIndex]} {matrix[matrixRowIndex+2][matrixColIndex + 1]} {matrix[matrixRowIndex+2][matrixColIndex + 2]}");
		}
	}
}
