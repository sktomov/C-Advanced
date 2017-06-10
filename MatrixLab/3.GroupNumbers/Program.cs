using System;
using System.Linq;

namespace _3.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int row = 0; row < matrix.Length; row++)
            {
                
                matrix[row] = input.Where(a =>Math.Abs(a) % 3 == 0 + row).ToArray();
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
