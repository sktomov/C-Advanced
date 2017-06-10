using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StudentResults
{
	class StudentResults
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var sb = new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				var firstSeparator = " - ";
				var secondSeparator = ", ";
				var input = Console.ReadLine().Split(new []{firstSeparator}, StringSplitOptions.RemoveEmptyEntries);
				var student = input[0];
				var marksArr = input[1].Split(new[] {secondSeparator}, StringSplitOptions.RemoveEmptyEntries);
				var cadv = double.Parse(marksArr[0]);
				var coop = double.Parse(marksArr[1]);
				var advoop = double.Parse(marksArr[2]);
				var average = (cadv + coop + advoop) / 3;
				if (i == 0)
				{
					sb.AppendLine(string.Format("{0, -10}|{1, 7}|{2, 7}|{3, 7}|{4, 7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
					sb.AppendLine(string.Format("{0, -10}|{1, 7:f2}|{2, 7:f2}|{3, 7:f2}|{4, 7:f4}|", student, cadv, coop, advoop, average));
				}
				else
				{
					sb.AppendLine(string.Format("{0, -10}|{1, 7:f2}|{2, 7:f2}|{3, 7:f2}|{4, 7:f4}|", student,cadv, coop, advoop, average));
				}
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
