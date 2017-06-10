using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
	public static class IOManager
	{
		public static void TraverseDirectory(int depth)
		{
			OutputWriter.WriteEmptyLine();
			int initialIdentation = SessionData.currentPath.Split('\\').Length;
			Queue<string> subFolders = new Queue<string>();
			subFolders.Enqueue(SessionData.currentPath);

			while (subFolders.Count != 0)
			{
				string currentPath = subFolders.Dequeue();
				int identation = currentPath.Split('\\').Length - initialIdentation;
				if (depth - identation < 0)
				{
					break;
				}
				OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
				foreach (var directoryPath in Directory.GetDirectories(currentPath))
				{
					subFolders.Enqueue(directoryPath);
				}
				foreach (var file in Directory.GetFiles(currentPath))
				{
					int indexOfSlash = file.LastIndexOf('\\');
					string fileName = file.Substring(indexOfSlash);
					OutputWriter.WriteMessageOnNewLine(new string('-', indexOfSlash) + fileName);
				}
			}
		}

		public static void CreateDirectoryInCurrentFolder(string name)
		{
			string path = $"{SessionData.currentPath}\\{name}";
			Directory.CreateDirectory(path);
		}

		public static void ChangeCurrentDirectoryRelative(string relativePath)
		{
			if (relativePath == "..")
			{
				string currentPath = SessionData.currentPath;
				int indexOfSlash = currentPath.LastIndexOf('\\');
				string newPath = currentPath.Substring(0, indexOfSlash);
				SessionData.currentPath = newPath;
			}
			else
			{
				string currentPath = SessionData.currentPath;
				currentPath += "\\" + relativePath;
				ChangeCurrentDirectoryAbsolute(currentPath);
			}
		}

		public static void ChangeCurrentDirectoryAbsolute(string currentPath)
		{
			
		}
	}
}
