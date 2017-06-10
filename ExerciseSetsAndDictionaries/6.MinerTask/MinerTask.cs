using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MinerTask
{
    public static void Main()
    {
        var input = Console.ReadLine();

        var dict = new Dictionary<string, long>();
        var counter = 1;
        string previousKey = string.Empty;
        while (input != "stop")
        {
            if(counter % 2 != 0)
            {
                previousKey = input;
                if (!dict.ContainsKey(input))
                {
                    dict[input] = 0;
                    
                }
            }
            else if (counter % 2 == 0)
            {
                
                var oldValue = dict[previousKey];
                dict[previousKey] = oldValue + long.Parse(input);
            }
            
            counter++;
            input = Console.ReadLine();
        }
        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}
