using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Srabsko
{
    static void Main()
    {
        var input = Console.ReadLine();
        string pattern = @"(([A-Za-z]+\s){1,})@(([A-Za-z]+\s){1,})(\d+)\s(\d+)";
        var venues = new Dictionary<string, Dictionary<string, decimal>>();
        while (input != "End")
        {
            var regex = new Regex(pattern);
            var match = regex.Match(input);

            if (match.Success)
            {
                var singer = match.Groups[1].Value.Trim();
                var venue = match.Groups[3].Value.Trim();
                var priceTicket = decimal.Parse(match.Groups[5].Value);
                var countTicket = decimal.Parse(match.Groups[6].Value);

                var value = priceTicket * countTicket;
                if (!venues.ContainsKey(venue))
                {
                    venues.Add(venue, new Dictionary<string, decimal>());
                }
                if (!venues[venue].ContainsKey(singer))
                {
                    venues[venue].Add(singer, 0);
                }
                venues[venue][singer] += value;
            }


            input = Console.ReadLine();
        }
        foreach (var venue in venues)
        {
            Console.WriteLine($"{venue.Key}");
            foreach (var singer in venue.Value.OrderByDescending(a => a.Value))
            {
                Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
            }
        }
    }
}

