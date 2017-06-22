using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.StudentsByPhone
{
	class StudentsByPhone
	{
		static void Main()
		{
			var input = Console.ReadLine();
			List<string[]> students = new List<string[]>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				if (studentsArrs.Last().StartsWith("02") || studentsArrs.Last().StartsWith("+3592"))
				{
					studentsArrs = new string[]
					{
						studentsArrs[0],
						studentsArrs[1]
					};
					students.Add(studentsArrs);
				}

				input = Console.ReadLine();
			}
			foreach (var student in students)
			{
				Console.WriteLine(string.Join(" ", student));
			}
		}
	}
}
