using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            SortedSet<string> periodicTable = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                foreach (var element in arr)
                {
                    periodicTable.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ",periodicTable));
        }
    }
}
