using System;
using System.Collections.Generic;
using System.Linq;

namespace StartUp
{
    public class Program
    {
        public static void Main()
        {
            //1.	Parking Lot
            //ParkingLot();

            //2.	 SoftUni Party
            //SoftUniParty();

            //3.	 Count Same Values in Array
            //SameValues();

            //4.Academy Graduation
            var n = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> dict = new SortedDictionary<string,List<double>>();
            for (int i = 0; i < n; i++)
            {
                var student = Console.ReadLine();

                var grades = Console.ReadLine().Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
                dict.Add(student, grades);    

            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }

        private static void SameValues()
        {
            SortedDictionary<decimal, int> dict = new SortedDictionary<decimal, int>();
            var input = Console.ReadLine().Trim().Split(' ').Select(decimal.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 0;
                }
                dict[input[i]]++;
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }

        private static void SoftUniParty()
        {
            SortedSet<string> guests = new SortedSet<string>();

            var input = Console.ReadLine();
            while (!input.Equals("PARTY"))
            {
                guests.Add(input);
                input = Console.ReadLine();
            }
            while (!input.Equals("END"))
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }

        private static void ParkingLot()
        {
            var input = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> set = new SortedSet<string>();
            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    set.Add(input[1]);
                }
                else
                {
                    set.Remove(input[1]);
                }
                input = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var registration in set)
                {
                    Console.WriteLine(registration.Trim());
                }
            }
        }
    }
}
