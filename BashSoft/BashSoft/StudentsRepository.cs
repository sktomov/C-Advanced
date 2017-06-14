using System;
using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
	public static class StudentsRepository
	{
		public static bool isDataInitialized = false;
		private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

		public static void InitializeData(string fileName)
		{
			if (!isDataInitialized)
			{
				OutputWriter.WriteMessageOnNewLine("Reading data...");
				studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
				ReadData(fileName);
			}
			else
			{
				OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
			}
		}

		private static void ReadData(string fileName)
		{
			string input = Console.ReadLine();
			string path = SessionData.currentPath + "\\" + fileName;
			while (!string.IsNullOrEmpty(input))
			{
				
				input = Console.ReadLine();
			}
			if (File.Exists(path))
			{
				string[] allInputLines = File.ReadAllLines(path);
				for (int line = 0; line < allInputLines.Length; line++)
				{
					if (!string.IsNullOrEmpty(allInputLines[line]))
					{
						string[] data = allInputLines[line].Split(' ');
						string course = data[0];
						string student = data[1];
						int mark = int.Parse(data[2]);
						if (!studentsByCourse.ContainsKey(course))
						{
							studentsByCourse[course] = new Dictionary<string, List<int>>();
						}
						if (!studentsByCourse[course].ContainsKey(student))
						{
							studentsByCourse[course][student] = new List<int>();
						}
						studentsByCourse[course][student].Add(mark);
					}
				}
				isDataInitialized = true;
				OutputWriter.WriteMessageOnNewLine("Data read!");
			}
			else
			{
				OutputWriter.DisplayException(ExceptionMessages.FileDoesNotExist);
			}
			
		}

		private static bool IsQueryForCoursePossible(string courseName)
		{
			if (isDataInitialized)
			{
				if (studentsByCourse.ContainsKey(courseName))
				{
					return true;
				}
				else
				{
					OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
					return false;
				}
			}
			else
			{
				OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
			}
			return false;
		}

		private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
		{
			if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
			{
				return true;
			}
			else
			{
				OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
			}
			return false;
		}

		public static void GetStudentScoresFromCourse(string courseName, string username)
		{
			if (IsQueryForStudentPossible(courseName, username))
			{
				OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
			}
		}

		public static void GetAllStudentsFromCourse(string courseName)
		{
			if (IsQueryForCoursePossible(courseName))
			{
				OutputWriter.WriteMessageOnNewLine($"{courseName}:");
				foreach (var studentMarkEntry in studentsByCourse[courseName])
				{
					OutputWriter.PrintStudent(studentMarkEntry);
				}
			}
		}
	}
}
