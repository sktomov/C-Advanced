using System;
using System.Collections.Generic;

namespace _2.SetsOfElements
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);

            var firstSet = new HashSet<int>();
            var resultSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < m; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (firstSet.Contains(number))
                {
                    resultSet.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", resultSet));
        }
    }
}
