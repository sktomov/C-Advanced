using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PredicateParty
{
	class Party
	{
		static void Main()
		{
			var guests = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			while (commands[0] != "Party!")
			{
				switch (commands[1])
				{
					case "StartsWith":
						guests = StartsWith(guests, commands[2], commands[0]);
						break;
					case "EndsWith":
						guests = EndsWith(guests, commands[2], commands[0]);
						break;
					case "Length":
						guests = Length(guests, int.Parse(commands[2]), commands[0]);
						break;
				}
				commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			}
			if (guests.Count != 0)
			{
				Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
			}
			else
			{
				Console.WriteLine("Nobody is going to the party!");
			}
		}

		private static List<string> Length(List<string> guests, int length, string command)
		{
			var guestsToReturn = new List<string>();
			guestsToReturn.AddRange(guests);
			if (command == "Double")
			{
				foreach (var guest in guests)
				{
					if (guest.Length == length)
					{
						var index = guests.IndexOf(guest);
						guestsToReturn.Insert(index, guest);
					}
				}
			}
			else if (command == "Remove")
			{
				foreach (var guest in guests)
				{
					if (guest.Length == length)
					{
						guestsToReturn.Remove(guest);
					}
				}
			}

			return guestsToReturn;
		}

		private static List<string> EndsWith(List<string> guests, string searchString, string command)
		{
			var guestsToReturn = new List<string>();
			guestsToReturn.AddRange(guests);
			if (command == "Double")
			{
				foreach (var guest in guests)
				{
					if (guest.EndsWith(searchString))
					{
						var index = guests.IndexOf(guest);
						guestsToReturn.Insert(index, guest);
					}
				}
			}
			else if (command == "Remove")
			{
				foreach (var guest in guests)
				{
					if (guest.EndsWith(searchString))
					{
						guestsToReturn.Remove(guest);
					}
				}
			}

			return guestsToReturn;
		}

		private static List<string> StartsWith(List<string> guests, string searchString, string command)
		{
			var guestsToReturn = new List<string>();
			guestsToReturn.AddRange(guests);
			if (command == "Double")
			{
				foreach (var guest in guests)
				{
					if (guest.StartsWith(searchString))
					{
						var index = guests.IndexOf(guest);
						guestsToReturn.Insert(index, guest);
					}
				}
			}
			else if (command == "Remove")
			{
				foreach (var guest in guests)
				{
					if (guest.StartsWith(searchString))
					{
						guestsToReturn.Remove(guest);
					}
				}
			}

			return guestsToReturn;
		}
	}
}
