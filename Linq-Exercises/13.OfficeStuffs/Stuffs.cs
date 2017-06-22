using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.OfficeStuffs
{
	class Stuffs
	{
		static void Main()
		{
			var companies = new Dictionary<string, Dictionary<string, long>>();
			var n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				var inputLine = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
				var companyName = inputLine[0].Substring(1);
				var product = inputLine[4].Substring(0, inputLine[4].Length - 1);
				var quantity = long.Parse(inputLine[2]);
				if (!companies.ContainsKey(companyName))
				{
					companies.Add(companyName, new Dictionary<string, long>());
				}
				if (!companies[companyName].ContainsKey(product))
				{
					companies[companyName].Add(product, quantity);
				}
				else
				{
					var oldQuantity = companies[companyName][product];
					companies[companyName][product] = oldQuantity + quantity;
				}
				
			}
			var sb = new StringBuilder();
			foreach (var company in companies.OrderBy(x => x.Key))
			{
				sb.Append($"{company.Key}: ");
				var currentLine = string.Empty;
				foreach (var product in company.Value)
				{
					currentLine += $"{product.Key}-{product.Value}, ";
				}

				currentLine = currentLine.Trim(new char[] { ' ', ',' });
				sb.AppendLine(currentLine);
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
