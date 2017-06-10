using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MatrixRotation
{
	class Rotation
	{
		static void Main(string[] args)
		{
			string rotate = Console.ReadLine();
			string[] integer = rotate.Split('(');
			integer[1] = integer[1].Remove(integer[1].Length - 1, 1);
			string text = Console.ReadLine();
			int degrees = int.Parse(integer[1]);
			
			List<string> list = new List<string>();
			int longestWord = 0;

			while (text != "END")
			{
				list.Add(text);
				if (longestWord < text.Length)
				{
					longestWord = text.Length;
				}
				text = Console.ReadLine();
			}

			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Length < longestWord)
				{
					list[i] = list[i] + new string(' ', longestWord - list[i].Length);
				}
			}

			if (degrees == 180 || degrees % 360 == 180)
			{
				for (int i = list.Count - 1; i >= 0; i--)
				{
					for (int j = list[i].Length - 1; j >= 0; j--)
					{
						Console.Write(list[i][j]);
					}
					Console.WriteLine();
				}
			}

			char[,] rotate90 = new char[longestWord, list.Count];

			for (int row = 0; row < longestWord; row++)
			{
				for (int col = 0; col < list.Count; col++)
				{
					rotate90[row, col] = list[col][row];
				}
			}

			if (degrees == 270 || degrees % 360 == 270)
			{

				for (int i = rotate90.GetLength(0) - 1; i >= 0; i--)
				{
					for (int j = 0; j < rotate90.GetLength(1); j++)
					{
						Console.Write(rotate90[i, j]);
					}
					Console.WriteLine();
				}
			}

			if (degrees == 90 || degrees % 360 == 90)
			{
				for (int i = 0; i < rotate90.GetLength(0); i++)
				{
					for (int j = rotate90.GetLength(1) - 1; j >= 0; j--)
					{
						Console.Write(rotate90[i, j]);
					}
					Console.WriteLine();
				}
			}
			//test

			if (degrees == 0 || degrees % 360 == 0)
			{
				foreach (var rotate360 in list)
				{
					Console.WriteLine(rotate360);
				}
			}
		}
	}
}
