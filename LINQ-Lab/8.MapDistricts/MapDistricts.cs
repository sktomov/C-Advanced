using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.MapDistricts
{
	class MapDistricts
	{
		static void Main()
		{
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			var bound = long.Parse(Console.ReadLine());
			Dictionary<string, List<long>> cities = new Dictionary<string, List<long>>();
			foreach (var element in input)
			{
				var arr = element.Split(new []{':'}, StringSplitOptions.RemoveEmptyEntries);
				var city = arr[0];
				var population = long.Parse(arr[1]);
				if (!cities.ContainsKey(city))
				{
					cities[city] = new List<long>();
				}
				cities[city].Add(population);
			}
			cities.Where(s => s.Value.Sum()>=bound).OrderByDescending(s => s.Value.Sum()).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {string.Join(" ", x.Value.OrderByDescending(v => v).Take(5))}"));
		}
	}
}
