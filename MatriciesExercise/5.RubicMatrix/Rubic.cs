using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RubicMatrix
{
	class Rubic
	{
		static void Main()
		{
			var matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var matrix = new int[matrixDimensions[0]][];
			CreateMatrix(matrixDimensions, matrix);
			var commands = int.Parse(Console.ReadLine());
			for (int i = 0; i < commands; i++)
			{
				var inputComands = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
				var index = int.Parse(inputComands[0]);
				var command = inputComands[1];
				var moves = int.Parse(inputComands[2]);

				switch (command)
				{
					case "up":
						MoveCol(matrix, index, moves);
						break;
					case "down":
						MoveCol(matrix, index, matrix.Length - moves % matrix.Length);
						break;
					case "left":
						MoveRow(matrix, index, moves);
						break;
					case "right":
						MoveRow(matrix, index, matrix[0].Length - moves % matrix[0].Length);
						break;
				}
			}

			var element = 1;
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
				{
					if (matrix[rowIndex][colIndex] == element)
					{
						Console.WriteLine("No swap required");
					}
					else
					{
						for (int rIndex = 0; rIndex < matrix.Length; rIndex++)
						{
							for (int cIndex = 0; cIndex < matrix[0].Length; cIndex++)
							{
								if (matrix[rIndex][cIndex] == element)
								{
									var currentElement = matrix[rowIndex][colIndex];
									matrix[rowIndex][colIndex] = element;
									matrix[rIndex][cIndex] = currentElement;
									Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({rIndex}, {cIndex})");
									break;
								}
							}
						}
					}
					element++;
				}
			}
		}

		private static void MoveRow(int[][] matrix, int index, int moves)
		{
			var temp = new int[matrix[0].Length];
			for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
			{
				var test = (colIndex + moves) % matrix.Length;
				temp[colIndex] = matrix[index][(colIndex+moves) % matrix[0].Length];
			}
			//Overwrite matrix
			matrix[index] = temp;
		}

		private static void MoveCol(int[][] matrix, int index, int moves)
		{
			var temp = new int[matrix.Length];
			for (int rows = 0; rows < matrix.Length; rows++)
			{
				var test = (rows + moves) % matrix.Length;
				temp[rows] = matrix[(rows + moves) % matrix.Length][index];
			}
			//Overwrite matrix
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				matrix[rowIndex][index] = temp[rowIndex];
			}
		}

		private static void CreateMatrix(int[] matrixDimensions, int[][] matrix)
		{
			var counter = 1;
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				matrix[rowIndex] = new int[matrixDimensions[1]];
				for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
				{
					matrix[rowIndex][colIndex] = counter;
					counter++;
				}
			}
		}
	}
}
