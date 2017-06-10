﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.SlicingFile
{
	class SliceFile
	{
		static void Main()
		{
			Console.Write("Enter path for file: ");
			var path = Console.ReadLine();
			Console.Write("Enter number of parts: ");
			var parts = int.Parse(Console.ReadLine());
			var slicedFolder = @"..\..\Sliced\";
			var assembledFolder = @"..\..\Assembled\";
			Slice(path, slicedFolder, parts);
			var files = Directory.GetFiles(slicedFolder).ToList();
			Assemble(files, assembledFolder, parts);

		}

		private static void Assemble(List<string> files, string assembledFolder, int parts)
		{
			var extension = files.First().Split('.').Last();
			var path = assembledFolder + "assembled" + "." + extension;
			using (var writer = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				foreach (var file in files)
				{
					using (var reader = new FileStream(file, FileMode.Open))
					{
						var buffer = new byte[reader.Length];
						var readedBytes = reader.Read(buffer, 0, buffer.Length);
						while (readedBytes != 0)
						{
							writer.Write(buffer, 0, readedBytes);
							readedBytes = reader.Read(buffer, 0, buffer.Length);
						}

					}
				}
				Console.WriteLine("Succesfully assembled!");
			}
		}

		private static void Slice(string path, string slicedFolder, int parts)
		{
			using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				var fileLength = reader.Length;
				var partLenght = fileLength / parts + fileLength % parts;
				var buffer = new byte[partLenght];

				var readedBytes = reader.Read(buffer, 0, buffer.Length);
				var partExtension = 1;
				while (readedBytes != 0)
				{
					var newPath = string.Empty;
					if (path.Contains('\\'))
					{
						newPath = path.Split('\\').Last();
					}
					var extension = newPath.Substring(newPath.LastIndexOf('.'));
					var fileName = newPath.Replace(extension, "");
					newPath = slicedFolder + fileName+"-"+partExtension + extension;
					using (var writer = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.Write))
					{
						writer.Write(buffer, 0, buffer.Length);
						partExtension++;
					}
					readedBytes = reader.Read(buffer, 0, buffer.Length);
				}
				Console.WriteLine("Succesfully sliced!");

			}
		}
	}
}
