using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.StudentsByEmail
{
	class StudentsByEmail
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			List<string[]> students = new List<string[]>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				if (studentsArrs.Any(s => s.EndsWith("@gmail.com")))
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
