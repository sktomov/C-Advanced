using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.StudentsByAge
{
	class StudentsByAge
	{
		static void Main()
		{
			var input = Console.ReadLine();
			List<string> students = new List<string>();
			while (input != "END")
			{
				var studentsArrs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				var firstName = studentsArrs[0];
				var lastName = studentsArrs[1];
				var age = int.Parse(studentsArrs[2]);
				if (age >= 18 && age <= 24)
				{
					students.Add(input);
				}

				input = Console.ReadLine();
			}
			students.ForEach(s => Console.WriteLine(s));
		}
	}
}
