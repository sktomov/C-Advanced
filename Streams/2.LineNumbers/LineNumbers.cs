using System;
using System.IO;

namespace _2.LineNumbers
{
	class LineNumbers
	{
		static void Main()
		{
			Console.WriteLine("Reading..");
			var path = "../../test.txt";
			var result = "../../result.txt";
			using (var reader = new StreamReader(path))
			{
				var readLine = reader.ReadLine();

				using (var writer = new StreamWriter(result))
				{
					while (true)
					{
						writer.WriteLine(readLine);
						readLine = reader.ReadLine();
						if (readLine == null)
						{
							break;
						}
					}
				}
			}
		}
	}
}
