using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Bunnies
{
	public class Player
	{
		public int Row { get; set; }
		public int Col { get; set; }
	}
	public class Bunnies
	{
		public static void Main(string[] args)
		{
			var matrixSize = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToArray();
			var rows = matrixSize[0];
			var cols = matrixSize[1];
			var matrix = new char[rows][];
			for (int rowIndex = 0; rowIndex < rows; rowIndex++)
			{
				matrix[rowIndex] = new char[cols];
				matrix[rowIndex] = Console.ReadLine().ToCharArray();
			}

			var player = FindPlayerPosition(matrix);
			var result = new StringBuilder();
			var commands = Console.ReadLine().ToCharArray();
			foreach (var command in commands)
			{
				
				if (command.Equals('U'))
				{
					if (!matrix.Any(a => a.Contains('P')))
					{
						result.AppendLine($"dead: {player.Row} {player.Col}");
						break;
					}
					if (player.Row <= 0)
					{
						result.AppendLine($"won: {player.Row} {player.Col}");
						matrix[player.Row][player.Col] = '.';
						matrix = CloneBunnies(matrix);
						break;
					}
					if (matrix[player.Row - 1][player.Col] == 'B')
					{
						result.AppendLine($"dead: {player.Row-1} {player.Col}");
						matrix[player.Row][player.Col] = 'B';
						matrix = CloneBunnies(matrix);
						break;
					}
					matrix[player.Row - 1][player.Col] = 'P';
					matrix[player.Row][player.Col] = '.';
					player.Row--;
				}
				else if (command.Equals('D'))
				{
					if (!matrix.Any(a => a.Contains('P')))
					{
						result.AppendLine($"dead: {player.Row} {player.Col}");
						break;
					}
					if (player.Row >= matrix.Length - 1)
					{
						result.AppendLine($"won: {player.Row} {player.Col}");
						matrix[player.Row][player.Col] = '.';
						matrix = CloneBunnies(matrix);
						break;
					}
					if (matrix[player.Row+1][player.Col] == 'B')
					{
						result.AppendLine($"dead: {player.Row+1} {player.Col}");
						matrix[player.Row][player.Col] = 'B';
						matrix = CloneBunnies(matrix);
						break;
					}
					matrix[player.Row + 1][player.Col] = 'P';
					matrix[player.Row][player.Col] = '.';
					player.Row++;
				}
				else if (command.Equals('R'))
				{
					if (!matrix.Any(a => a.Contains('P')))
					{
						result.AppendLine($"dead: {player.Row} {player.Col}");
						break;
					}
					if (player.Col >= cols-1)
					{
						result.AppendLine($"won: {player.Row} {player.Col}");
						matrix[player.Row][player.Col] = '.';
						matrix = CloneBunnies(matrix);
						break;
					}
					if (matrix[player.Row][player.Col +1] == 'B')
					{
						result.AppendLine($"dead: {player.Row} {player.Col+1}");
						matrix[player.Row][player.Col+1] = 'B';
						matrix = CloneBunnies(matrix);
						break;
					}
					matrix[player.Row][player.Col+1] = 'P';
					matrix[player.Row][player.Col] = '.';
					player.Col++;
				}
				else if (command.Equals('L'))
				{
					if (!matrix.Any(a => a.Contains('P')))
					{
						result.AppendLine($"dead: {player.Row} {player.Col}");
						break;
					}
					if (player.Col <= 0)
					{
						result.AppendLine($"won: {player.Row} {player.Col}");
						matrix[player.Row][player.Col] = '.';
						matrix = CloneBunnies(matrix);
						break;
					}
					if (matrix[player.Row][player.Col - 1] == 'B')
					{
						result.AppendLine($"dead: {player.Row} {player.Col}");
						
						matrix = CloneBunnies(matrix);
						matrix[player.Row][player.Col] = 'B';
						break;
					}
					matrix[player.Row][player.Col - 1] = 'P';
					matrix[player.Row][player.Col] = '.';
					player.Col--;
				}
				matrix = CloneBunnies(matrix);
			}
			PrintResult(matrix, result);
		}

		private static void PrintResult(char[][] matrix, StringBuilder result)
		{
			foreach (var row in matrix)
			{
				Console.WriteLine(string.Join("",row));
			}
			Console.WriteLine(result.ToString());
		}

		private static char[][] CloneBunnies(char[][] matrix)
		{
			var temp = new char[matrix.Length][];
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				temp[rowIndex] = new char[matrix[rowIndex].Length];
			}
			for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
			{
				for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
				{
					if (matrix[rowIndex][colIndex] == 'B')
					{
						var upCell = Math.Max(0, rowIndex - 1);
						var downCell = Math.Min(rowIndex + 1, matrix.Length - 1);
						var leftCell = Math.Max(0, colIndex - 1);
						var rightCell = Math.Min(colIndex + 1, matrix[rowIndex].Length - 1);

						temp[rowIndex][colIndex] = 'B';
						temp[upCell][colIndex] = 'B';
						temp[downCell][colIndex] = 'B';
						temp[rowIndex][leftCell] = 'B';
						temp[rowIndex][rightCell] = 'B';
					}
					else if (matrix[rowIndex][colIndex] == 'P')
					{
						temp[rowIndex][colIndex] = 'P';
					}
					else if (temp[rowIndex][colIndex] == 0)
					{
						temp[rowIndex][colIndex] = '.';
					}
				}
			}

			return temp;
		}

		public static Player FindPlayerPosition(char[][] matrix)
		{
			var player = new Player();
			for (int row = 0; row < matrix.Length; row++)
			{
				for (int col = 0; col < matrix[row].Length; col++)
				{
					if (matrix[row][col].Equals('P'))
					{
						player.Col = col;
						player.Row = row;
						break;
					}
				}
			}

			return player;
		}


	}
}
