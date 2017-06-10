using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _8.FullDirectoryTraversal
{
	class FullDirectoryTraversal
	{
		public static void Main()
		{
			Console.Write("Enter a path of directory: ");
			var input = Console.ReadLine();
			CheckIsDirectoryExist(input);
			var allFolders = Directory.GetFiles(input, "*", SearchOption.AllDirectories);
			Dictionary<string, Dictionary<string, double>> info = CollectingData(allFolders);

			//GetSubfoldersInfo(subfolders, info);
			OrderingAndWriteFile(info);

		}

		private static void GetSubfoldersInfo(string[] subfolders, Dictionary<string, Dictionary<string, double>> info)
		{
			foreach (var subfolder in subfolders)
			{
				var fileInfo = new FileInfo(subfolder);
				var extension = fileInfo.Extension;
				var fileName = fileInfo.Name;
				var fileSize = (double)fileInfo.Length / 1024;
				if (!info.ContainsKey(extension))
				{
					info[extension] = new Dictionary<string, double>();
				}
				info[extension].Add(fileName, fileSize);
			}
		}

		private static void OrderingAndWriteFile(Dictionary<string, Dictionary<string, double>> info)
		{
			var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";
			var sb = new StringBuilder();
			foreach (var file in info.OrderByDescending(a => a.Value.Values.Count).ThenBy(n => n.Key))
			{
				sb.AppendLine(file.Key);
				foreach (var fileInfo in file.Value.OrderBy(s => s.Value))
				{
					sb.AppendLine($"--{fileInfo.Key} - {fileInfo.Value}kb");
				}

			}
			File.WriteAllText(desktopPath, sb.ToString());
			Console.WriteLine("File report.txt is in your desktop.");

		}

		private static Dictionary<string, Dictionary<string, double>> CollectingData(string[] input)
		{
			var dict = new Dictionary<string, Dictionary<string, double>>();
			foreach (var file in input)
			{

				var fileInfo = new FileInfo(file);
				var extension = fileInfo.Extension;
				var fileName = fileInfo.Name;
				var fileSize = (double)fileInfo.Length / 1024;
				if (!dict.ContainsKey(extension))
				{
					dict[extension] = new Dictionary<string, double>();
				}
				if (!dict[extension].ContainsKey(fileName))
				{
					dict[extension][fileName] = 0;
				}
				dict[extension][fileName] = fileSize;
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
