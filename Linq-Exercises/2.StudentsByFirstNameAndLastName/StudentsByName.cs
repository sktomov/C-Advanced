using System;
using System.Collections.Generic;

namespace _2.StudentsByFirstNameAndLastName
{
	class StudentsByName
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
				if (string.Compare(firstName, lastName) < 0)
				{
					students.Add(input);
				}

				input = Console.ReadLine();
			}
			students.ForEach(s => Console.WriteLine(s));
		}
	}
}
