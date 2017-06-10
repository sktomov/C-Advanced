using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materialsName = new Dictionary<string, string>();
            materialsName.Add("shards", "Shadowmourne");
            materialsName.Add("fragments", "Valanyr");
            materialsName.Add("motes", "Dragonwrath");

            var arr = Console.ReadLine().ToLower().Split().ToArray();

            var junkMateriales = new SortedDictionary<string, int>();
            var keyMateriales = new Dictionary<string, int>();

            keyMateriales.Add("shards", 0);
            keyMateriales.Add("fragments", 0);
            keyMateriales.Add("motes", 0);

            while (true)
            {
                var currentMaterials = arr.Where((x, i) => i % 2 == 1).ToArray();
                var quantity = arr.Where((x, i) => i % 2 == 0).Select(int.Parse).ToArray();

                bool hasObtained = false;

                for (int i = 0; i < currentMaterials.Length; i++)
                {
                    string currentMaterial = currentMaterials[i];

                    if (materialsName.Keys.Contains(currentMaterial))
                    {
                        keyMateriales[currentMaterial] += quantity[i];

                        if (keyMateriales.Values.Any(x => x >= 250))
                        {
                            hasObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMateriales.ContainsKey(currentMaterial))
                        {
                            junkMateriales.Add(currentMaterial, 0);
                        }

                        junkMateriales[currentMaterial] += quantity[i];
                    }
                }

                if (hasObtained)
                {
                    break;
                }

                arr = Console.ReadLine().ToLower().Split().ToArray();
            }

            var obtainedElementName = keyMateriales
                .Where(x => x.Value >= 250)
                .First()
                .Key;

            keyMateriales[obtainedElementName] -= 250;

            keyMateriales = keyMateriales
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{materialsName[obtainedElementName]} obtained!");

            var result = keyMateriales.Concat(junkMateriales).ToDictionary(x => x.Key, x => x.Value);

            foreach (var material in result)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
