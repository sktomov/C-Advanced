using System;
using System.IO;

namespace _4.CopyBinaryFile
{
	public class BinaryFile
	{
		public static void Main()
		{
			Console.Write("Give path  or tab 1 for static path: ");
			var path = Console.ReadLine();
			if (path.Equals("1"))
			{
				path = "../../znak.jpg";
			}
			Console.Write("Enter output file path or tab 1 for static path: ");
			var outputfile = Console.ReadLine();
			if (outputfile.Equals("1"))
			{
				outputfile = "../../znak-copy.jpg";
			}

			using (var reader = new FileStream(path, FileMode.Open))
			{
				using (var writer = new FileStream(outputfile, FileMode.OpenOrCreate))
				{
					byte[] buffer = new byte[4096];
					while (true)
					{
						int fileLenght = reader.Read(buffer, 0, buffer.Length);
						if (fileLenght == 0)
						{
							break;
						}
						writer.Write(buffer, 0, fileLenght);
					}
					
				}
			}
			Console.WriteLine("Success!");
		}
	}
}
