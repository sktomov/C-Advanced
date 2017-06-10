using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {

        var input = Console.ReadLine();
        var players = new Dictionary<string, HashSet<string>>();
        while (input != "JOKER")
        {
            var arr = input.Split(':');
            var player = arr[0].Trim();
            var cards = arr[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (!players.ContainsKey(player))
            {
                players.Add(player, new HashSet<string>());
            }
            foreach (var card in cards)
            {
                players[player].Add(card);
            }
            input = Console.ReadLine();
        }
        foreach (var player in players)
        {
            double score = CalculateScore(player);
            Console.WriteLine($"{player.Key}: {score}");
        }
    }

    public static double CalculateScore(KeyValuePair<string, HashSet<string>> player)
    {
        var power = new List<string>()
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };
        var color = new List<string>()
        {
            "C", "D", "H", "S"
        };
        double score = 0;
        foreach (var card in player.Value)
        {
            var firstPower = power.IndexOf(card.Substring(0, card.Length - 1)) + 2;
            var secondPower = color.IndexOf(card.Substring(card.Length - 1)) + 1;
            score += firstPower * secondPower;
        }
        return score;
    }
}

