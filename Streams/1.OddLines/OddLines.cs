using System;
using System.IO;

namespace _1.OddLines
{
	public class OddLines
	{
		public static void Main()
		{
			Console.WriteLine("Reading file...");
			var path = "../../test.txt";
			using (var reader = new StreamReader(path))
			{
				Console.WriteLine("Success! Result:");
				var line = 0;
				var readLine = reader.ReadLine();
				while (readLine != null)
				{
					if (line % 2 == 0)
					{
						Console.WriteLine($"line->{line} {readLine}");
					}
					line++;
					readLine = reader.ReadLine();

				}
			}
		}
	}
}
