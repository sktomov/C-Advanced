using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SquaresInMatrix
{
	class Squares
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToArray();
			var matrix = new char[input[0]][];
			var result = 0;
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				matrix[rowIndex] = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
			}
			for (int rowIndex = 0; rowIndex < matrix.Length -1; rowIndex++)
			{
				for (int colIndex = 0; colIndex < matrix[rowIndex].Length -1; colIndex++)
				{
					result += FindSquares(matrix, rowIndex, colIndex);
				}
			}
			Console.WriteLine(result);
		}

		private static int FindSquares(char[][] matrix, int rowIndex, int colIndex)
		{
			if (matrix[rowIndex][colIndex] == matrix[rowIndex][colIndex + 1] &&
			    matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex] &&
			    matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex + 1])
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}
}
