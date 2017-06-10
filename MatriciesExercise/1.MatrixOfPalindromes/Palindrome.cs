using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Palindrome
{
	public static void Main()
	{
		var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		var matrix = new string[input[0]][];
		char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

		for (int row = 0; row < matrix.Length; row++)
		{
			matrix[row] = new string[input[1]];
			for (int col = 0; col < matrix[row].Length; col++)
			{
				matrix[row][col] = $"{alphabet[row]}{alphabet[row +col]}{alphabet[row]}";
			}
			Console.WriteLine(string.Join(" ", matrix[row]));
		}

	}
}

