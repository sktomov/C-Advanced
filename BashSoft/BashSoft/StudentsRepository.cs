﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
				string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
				Regex regex = new Regex(pattern);
				string[] allInputLines = File.ReadAllLines(path);
				for (int line = 0; line < allInputLines.Length; line++)
				{
					if (!string.IsNullOrEmpty(allInputLines[line]) && regex.IsMatch(allInputLines[line]))
					{
						Match currentMatch = regex.Match(allInputLines[line]);
						string courseName = currentMatch.Groups[1].Value;
						string username = currentMatch.Groups[2].Value;
						int studentScoreOnTask;
						bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);
						if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
						{
							if (!studentsByCourse.ContainsKey(courseName))
							{
								studentsByCourse[courseName] = new Dictionary<string, List<int>>();
							}
							if (!studentsByCourse[courseName].ContainsKey(username))
							{
								studentsByCourse[courseName][username] = new List<int>();
							}
							studentsByCourse[courseName][username].Add(studentScoreOnTask);
						}

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
