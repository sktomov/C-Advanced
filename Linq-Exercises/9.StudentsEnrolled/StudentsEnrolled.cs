using System;
using System.Collections.Generic;

namespace _9.StudentsEnrolled
{
	class StudentsEnrolled
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var marks = new List<string>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				var facNumber = studentsArrs[0];
				
				if (facNumber.EndsWith("14") || facNumber.EndsWith("15"))
				{
					var grades = input.Substring(7);
					marks.Add(grades);
				}
				input = Console.ReadLine();
			}
			marks.ForEach(x => Console.WriteLine(x));
		}
	}
}
