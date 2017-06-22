using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ExcellentStudents
{
	class ExcellentStudents
	{
		static void Main(string[] args)
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
			students.Where(s => s.Value.Any(mark => mark == 6)).ToList().ForEach(x => Console.WriteLine($"{x.Key}"));
		}
	}
}
