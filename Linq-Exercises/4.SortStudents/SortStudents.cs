using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.SortStudents
{
	class SortStudents
	{
		static void Main()
		{
			var input = Console.ReadLine();
			List<string[]> students = new List<string[]>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				students.Add(studentsArrs);
				input = Console.ReadLine();
			}
			var result = students.OrderBy(f => f[1]).ThenByDescending(l => l[0]).ToList();
			foreach (var e in result)
			{
				Console.WriteLine($"{e[0]} {e[1]}");
			}
			
		}

		public class Student
		{
			public string FirstName { get; set; }

			public string LastName { get; set; }
		}
	}
}
