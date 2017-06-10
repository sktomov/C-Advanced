using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ParseUrls
{
	class Parse
	{
		static void Main()
		{
			var input = Console.ReadLine();
			var separator = "://";
			var arr = input.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
			
			if (arr.Length != 2)
			{
				Console.WriteLine("Invalid URL");
				return;
			}
			var indexSlash = arr[1].IndexOf('/');
			if (indexSlash < 0)
			{
				Console.WriteLine("Invalid URL");
				return;
			}
			else
			{
				var protocol = arr[0];
				var indexResource = arr[1].IndexOf('/');
				
				var server = arr[1].Substring(0, indexResource);
				var resources = arr[1].Substring(indexResource + 1);
				Console.WriteLine($"Protocol = {protocol}");
				Console.WriteLine($"Server = {server}");
				Console.WriteLine($"Resources = {resources}");
			}
		}
	}
}
