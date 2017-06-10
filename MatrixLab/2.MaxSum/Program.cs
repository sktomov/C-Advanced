using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            int maxSum = 0;
            int maxElementRowIndex = 0;
            int maxElementColIndex = 0;
            for (int row = 0; row < matrix.Length -1; row++)
            {
                for (int col = 0; col < matrix[row].Length-1; col++)
                {
                    var currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxElementRowIndex = row;
                        maxElementColIndex = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxElementRowIndex][maxElementColIndex]} {matrix[maxElementRowIndex][maxElementColIndex +1]}");
            Console.WriteLine($"{matrix[maxElementRowIndex + 1][maxElementColIndex]} {matrix[maxElementRowIndex+1][maxElementColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
