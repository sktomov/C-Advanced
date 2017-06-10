using System;
using System.Collections.Generic;
using System.Linq;


class PopulationCounter
{
    static void Main()
    {
        var input = Console.ReadLine().Split('|');
        var countries = new Dictionary<string, Dictionary<string, long>>();
        while (input[0] != "report")
        {
            if (!countries.ContainsKey(input[1]))
            {
                countries.Add(input[1], new Dictionary<string, long>());
                countries[input[1]][input[0]] = long.Parse(input[2]);
            }
            else
            {
                if (!countries[input[1]].ContainsKey(input[0]))
                {
                    countries[input[1]][input[0]] = long.Parse(input[2]);
                }
            }
            input = Console.ReadLine().Split('|');
        }
        foreach (var country in countries.OrderByDescending(c => c.Value.Values.Sum(b => b)))
        {
            Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum(b => b)})");
            foreach (var kvp in country.Value.OrderByDescending(a => a.Value))
            {
                Console.WriteLine($"=>{kvp.Key}: {kvp.Value}");
            }
        }
    }
}

