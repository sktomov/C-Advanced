using System;

class Pascal
{
    static void Main(string[] args)
    {

        var n = int.Parse(Console.ReadLine());
        long[][] matrix = new long[n][];


        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new long[row + 1];
            for (int col = 0; col < row + 1; col++)
            {

                if (col == 0 || col == matrix[row].Length - 1)
                {
                    matrix[row][col] = 1;
                }
                else
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
            }
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write($"{matrix[row][col]} ");
            }
            Console.WriteLine();
        }

    }
}

