﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLines
{
	public class StartUp
	{
		public static void Main()
		{
			Console.Write("Моля въведете път до файла, който искате да прочетете: ");
			var inputPath = Console.ReadLine();

			using (StreamReader streamReader = new StreamReader(inputPath))
			{
				int lineNumber = 1;
				string line = streamReader.ReadLine();
				while (line != null)
				{
					if (lineNumber % 2 != 0)
					{
						Console.WriteLine(line);
					}
					lineNumber++;
					line = streamReader.ReadLine();
				}
			}
		}
	}
}
