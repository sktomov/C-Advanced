using System;
using System.Collections.Generic;

namespace _4.CountElements
{
    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 0;
                }
                dict[input[i]] += 1;
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
