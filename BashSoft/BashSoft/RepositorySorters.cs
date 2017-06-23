using System;
using System.Collections.Generic;

namespace BashSoft
{
	public static class RepositorySorters
	{
		public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
		{
			comparison = comparison.ToLower();
			if (comparison == "ascending")
			{
				OrderAndTake(wantedData, studentsToTake, CompareInOrder);
			}
			else if (comparison == "descending")
			{
				OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder);
			}
			else
			{
				OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
			}
		}
		private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
		{

		}

		private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted,
			int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> Comparison)
		{
			int valuesTaken = 0;
			Dictionary<string, List<int>> sortedStudents = new Dictionary<string, List<int>>();
			KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
			bool isSorted = false;
			while (valuesTaken < takeCount)
			{
				isSorted = true;
				foreach (var studentWithScore in studentsWanted)
				{
					if (!String.IsNullOrEmpty(nextInOrder.Key))
					{
						int comparisonResult = Comparison(studentWithScore, nextInOrder);
						if (comparisonResult >= 0 && !sortedStudents.ContainsKey(studentWithScore.Key))
						{
							nextInOrder = studentWithScore;
							isSorted = false;
						}
					}
					else
					{
						if (!sortedStudents.ContainsKey(studentWithScore.Key))
						{
							nextInOrder = studentWithScore;
							isSorted = false;
						}
					}
				}
				if (!isSorted)
				{
					sortedStudents.Add(nextInOrder.Key, nextInOrder.Value);
					valuesTaken++;
					nextInOrder = new KeyValuePair<string, List<int>>();
				}
			}
			return sortedStudents;
		}

		private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
		{
			int totalOfFirstMarks = 0;
			foreach (var i in firstValue.Value)
			{
				totalOfFirstMarks += i;
			}
			int totalOfSecondMarks = 0;
			foreach (var i in secondValue.Value)
			{
				totalOfSecondMarks += i;
			}
			return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
		}
		private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
		{
			int totalOfFirstMarks = 0;
			foreach (var i in firstValue.Value)
			{
				totalOfFirstMarks += i;
			}
			int totalOfSecondMarks = 0;
			foreach (var i in secondValue.Value)
			{
				totalOfSecondMarks += i;
			}
			return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
		}
	}
}
