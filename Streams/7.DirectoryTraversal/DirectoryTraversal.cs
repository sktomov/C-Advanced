using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7.DirectoryTraversal
{
	public class DirectoryTraversal
	{
		public static void Main()
		{
			Console.Write("Enter a path of directory: ");
			var input = Console.ReadLine();
			CheckIsDirectoryExist(input);
			Dictionary<string, Dictionary<string, double>> info = CollectingData(input);
			OrderingAndWriteFile(info);

		}

		private static void OrderingAndWriteFile(Dictionary<string, Dictionary<string, double>> info)
		{
			var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";
			using (var writer = new StreamWriter(desktopPath))
			{
				foreach (var file in info.OrderByDescending(a => a.Value.Values.Count).ThenBy(n => n.Key))
				{

					writer.WriteLine(file.Key);
					foreach (var fileInfo in file.Value.OrderBy(s => s.Value))
					{
						writer.WriteLine($"--{fileInfo.Key} - {fileInfo.Value}kb");
					}

				}
			}
			Console.WriteLine("File report.txt is in your desktop.");

		}

		private static Dictionary<string, Dictionary<string, double>> CollectingData(string input)
		{
			var directoryInfo = Directory.GetFiles(input);
			var dict = new Dictionary<string, Dictionary<string, double>>();
			foreach (var file in directoryInfo)
			{
				var fileInfo = new FileInfo(file);
				var extension = fileInfo.Extension;
				var fileName = fileInfo.Name;
				var fileSize = (double)fileInfo.Length / 1024;
				if (!dict.ContainsKey(extension))
				{
					dict[extension] = new Dictionary<string, double>();
				}
				dict[extension].Add(fileName, fileSize);
			}
			return dict;
		}

		private static void CheckIsDirectoryExist(string input)
		{
			while (!Directory.Exists(input))
			{
				Console.Write("Invalid path");
				Console.Write("Enter a path of directory: ");
				input = Console.ReadLine();
			}
		}
	}
}
