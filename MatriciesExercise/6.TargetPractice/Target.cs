using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.TargetPractice
{
	class Target
	{
		static void Main()
		{
			var matrixSize = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToArray();
			var rows = matrixSize[0];
			var cols = matrixSize[1];

			var text = Console.ReadLine();
			var matrix = new char[rows][];
			FillMatrix(matrix, cols, text);
			//shotParameters 
			var shotParameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToArray();
			var targetRow = shotParameters[0];
			var targetCol = shotParameters[1];
			var radius = shotParameters[2];
			Shoot(matrix, targetRow, targetCol, radius);
			FailDownSnakes(matrix, cols);
			PrintResult(matrix);

		}

		private static void PrintResult(char[][] matrix)
		{
			foreach (var row in matrix)
			{
				Console.WriteLine(row);
			}
		}

		private static void FailDownSnakes(char[][] matrix, int cols)
		{
			for (int colIndex = 0; colIndex < cols ; colIndex++)
			{
				for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
				{
					if (matrix[rowIndex][colIndex] == ' ')
					{
						for (int i = rowIndex - 1; i >= 0; i--)
						{
							if (matrix[i][colIndex] != ' ')
							{
								matrix[rowIndex][colIndex] = matrix[i][colIndex];
								matrix[i][colIndex] = ' ';
								break;
							}
						}
					}
				}
			}
		}

		private static void Shoot(char[][] matrix, int targetRow, int targetCol, int radius)
		{
			for (int row = 0; row < matrix.Length; row++)
			{
				for (int col = 0; col < matrix[row].Length; col++)
				{
					var test = (row - targetRow) * (row - targetRow) + (col - targetCol) * (col - targetCol);
					bool isInCircle = ((row - targetRow)*(row-targetRow) + (col - targetCol)*(col - targetCol)) <= (radius*radius);
					if (isInCircle)
					{
						matrix[row][col] = ' ';
					}
				}
			}
		}

		private static void FillMatrix(char[][] matrix, int cols, string text)
		{
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				matrix[rowIndex] = new char[cols];
			}
			int counter = 0;
			bool direction = true;
			for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
			{
				if (!direction)
				{
					for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
					{
						var test = counter % text.Length;
						matrix[rowIndex][colIndex] = text[counter % text.Length];
						counter++;
					}

				}
				else
				{
					for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
					{
						var test = counter % text.Length;
						matrix[rowIndex][colIndex] = text[counter % text.Length];
						counter++;
					}
				}
				direction = !direction;
			}
		}
	}
}
