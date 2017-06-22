using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.GroupByGroup
{
	class GroupByGroup
	{
		static void Main()
		{
			var input = Console.ReadLine();
			var students = new List<Student>();
			while (input != "END")
			{
				var studentsArrs = input.Trim().Split();
				var name = studentsArrs[0] + " " + studentsArrs[1];
				var group = int.Parse(studentsArrs[2]);
				var student = new Student()
				{
					Name = name,
					Group = group
				};
				students.Add(student);
				input = Console.ReadLine();
			}
			students.GroupBy(s => s.Group).OrderBy(g => g.Key).ToList().ForEach(x => Console.WriteLine($"{x.Key} - {string.Join(", ", x.Select(n => n.Name))}"));
		}

	}
	public class Student
	{
		public string Name { get; set; }
		public int Group { get; set; }
	}
}
