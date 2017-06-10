using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Diagonal
{
	public static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var matrix = new int[n][];
		for (int rowIndex = 0; rowIndex < n; rowIndex++)
		{
			matrix[rowIndex] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
		}
		var primaryDiagonal = 0;
		var secondaryDiagonal = 0;

		for (int row = 0; row < matrix.Length; row++)
		{
			for (int colIndex = 0; colIndex < matrix[row].Length; colIndex++)
			{
				if (row == colIndex)
				{
					primaryDiagonal += matrix[row][colIndex];
				}
				if (row + colIndex == n - 1)
				{
					secondaryDiagonal += matrix[row][colIndex];
				}
			}
		}
		Console.WriteLine($"{Math.Abs(primaryDiagonal - secondaryDiagonal)}");
	}
}

