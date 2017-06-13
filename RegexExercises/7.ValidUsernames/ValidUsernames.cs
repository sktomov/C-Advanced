using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7.ValidUsernames
{
	class ValidUsernames
	{
		static void Main()
		{
			var separator = new char[] {' ', '/', '\\', ')', '('};
			var firstUser = string.Empty;
			var secondUser = string.Empty;
			var usernames = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
			string patern = @"^\b[A-Za-z]\w{2,25}\b";
			Regex regex = new Regex(patern);
			Queue<string> queue = new Queue<string>();
			foreach (var userName in usernames)
			{
				if (regex.IsMatch(userName))
				{
					queue.Enqueue(userName);
				}
			}
			var maxLenght = 0;
			while (queue.Count>1)
			{
				var first = queue.Dequeue();
				var sum = first.Length + queue.Peek().Length;
				if (maxLenght < sum)
				{
					maxLenght = sum;
					firstUser = first;
					secondUser = queue.Peek();
				}
			}
			Console.WriteLine(firstUser);
			Console.WriteLine(secondUser);

		}
	}
}
