using System;
using System.Collections.Generic;
using System.Text;

namespace _14.DragonArmy
{
    class DragonArmy
    {
        static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            var n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {

                var dragon = Console.ReadLine().Split(' ');
                var type = dragon[0];
                var dragonName = dragon[1];
                var dragonDamage = dragon[2].Equals("null") ? 45 : int.Parse(dragon[2]);
                var dragonHealth = dragon[3].Equals("null") ? 250 : int.Parse(dragon[3]);
                var dragonArmor = dragon[4].Equals("null") ? 10 : int.Parse(dragon[4]);
                if (dragons.ContainsKey(type))
                {
                    dragons[type][dragonName] = new int[] { dragonDamage, dragonHealth, dragonArmor };
                }
                else
                {
                    dragons[type] = new SortedDictionary<string, int[]>() { { dragonName, new int[] { dragonDamage, dragonHealth, dragonArmor } } };
                }
            }
            PrintAllDragons(dragons);
        }

        private static void PrintAllDragons(Dictionary<string, SortedDictionary<string, int[]>> dragons)
        {
            foreach (var dragon in dragons)
            {
                var sb = new StringBuilder();
                double avgDamage = 0, avgHealth = 0, avgArmor = 0;
                foreach (var info in dragon.Value)
                {
                    sb.Append($"-{info.Key} -> damage: {info.Value[0]}, health: {info.Value[1]}, armor: {info.Value[2]}\r\n");
                    avgDamage += info.Value[0];
                    avgHealth += info.Value[1];
                    avgArmor += info.Value[2];
                }
                avgDamage /= dragon.Value.Count;
                avgHealth /= dragon.Value.Count;
                avgArmor /= dragon.Value.Count;

                Console.WriteLine($"{dragon.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");
                Console.Write(sb.ToString());
            }
        }
    }
}
