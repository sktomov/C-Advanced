namespace _9.Crossfire
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Crossfire
	{
		public static void Main()
		{
			var matrix = InitializeMatrix();
			matrix = ExecuteCommands(matrix);
			PrintAliveCells(matrix);
		}

		private static void PrintAliveCells(int[][] matrix)
		{
			for (int i = 0; i < matrix.Length; i++)
			{
				Console.WriteLine(string.Join(" ", matrix[i].Where(c => c != -1)));
			}
		}

		private static int[][] ExecuteCommands(int[][] matrix)
		{
			var command = Console.ReadLine().Trim();

			while (command != "Nuke it from orbit")
			{
				var commandDetails = command
					.Split()
					.Select(int.Parse)
					.ToArray();

				var targetRow = commandDetails[0];
				var hitColumn = commandDetails[1];

				var targetRadius = commandDetails[2];

				matrix = DestroyMatrix(matrix, targetRow, hitColumn, targetRadius);

				command = Console.ReadLine().Trim();
			}

			return matrix;
		}

		private static int[][] DestroyMatrix(int[][] matrix, int hitRow, int hitCol, int radius)
		{
			// Mark destroyed part of the column
			for (int row = hitRow - radius; row <= hitRow + radius; row++)
			{
				if (IsInTheMatrix(row, hitCol, matrix))
				{
					matrix[row][hitCol] = -1;
				}
			}

			// Mark destroyed part of the row
			for (int col = hitCol - radius; col <= hitCol + radius; col++)
			{
				if (IsInTheMatrix(hitRow, col, matrix))
				{
					matrix[hitRow][col] = -1;
				}
			}

			// Remove destroyed cells
			for (int i = 0; i < matrix.Length; i++)
			{
				// Remove destroyed cells if there is ones
				for (int j = 0; j < matrix[i].Length; j++)
				{
					if (matrix[i][j] < 0)
					{
						matrix[i] = matrix[i].Where(n => n > 0).ToArray();
						break;
					}
				}

				// Remove empty rows
				if (matrix[i].Count() < 1)
				{
					matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
					i--;
				}
			}

			return matrix;
		}

		private static bool IsInTheMatrix(int row, int col, int[][] matrix)
		{
			return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
		}

		private static int[][] InitializeMatrix()
		{
			var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var currentCellNumber = 1;
			var matrix = new int[dimensions[0]][];

			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new int[dimensions[1]];

				for (int j = 0; j < matrix[i].Length; j++)
				{
					matrix[i][j] = currentCellNumber;
					currentCellNumber++;
				}
			}
			return matrix;
		}
	}
}