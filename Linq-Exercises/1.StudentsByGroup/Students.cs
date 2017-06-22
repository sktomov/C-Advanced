using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.StudentsByGroup
{
	class Students
	{
		static void Main()
		{
			var input = Console.ReadLine();
			List<string> students = new List<string>();
			while (input != "END")
			{
				var studentsArrs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
				var studentName = studentsArrs[0] + " " + studentsArrs[1];
				var studentGroup = int.Parse(studentsArrs[2]);
				if (studentGroup == 2)
				{
					students.Add(studentName);
				}

				input = Console.ReadLine();
			}
			students.OrderBy(a => a).ToList().ForEach(x => Console.WriteLine(x));
		}
	}
}
