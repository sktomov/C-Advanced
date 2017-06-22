using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.WeakStudents
{
	class WeakStudents
	{
		static void Main()
		{
			var input = Console.ReadLine();
			Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				var studentName = studentsArrs[0] + " " + studentsArrs[1];
				var grades = studentsArrs.Skip(2).Select(int.Parse).ToList();
				students.Add(studentName, grades);
				input = Console.ReadLine();
			}
			var std = students.Where(s => s.Value.Where(g => g <= 3).Count() > 1).ToList();
			foreach (var student in std)
			{
				Console.WriteLine(student.Key);
			}
		}
	}
}
