using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.StudentsJoinedtoSpecialties
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var students = new List<Student>();
			var specialties = new List<StudentSpecialty>();
			while (input != "Students:")
			{
				var arr = input.Trim().Split();
				var specialty = arr[0] + " " + arr[1];
				var facNumber = int.Parse(arr[2]);
				var studentSpecialty = new StudentSpecialty()
				{
					FacultyNumber =  facNumber,
					SpecialtyName = specialty
				};
				specialties.Add(studentSpecialty);
				input = Console.ReadLine();
			}
			input = Console.ReadLine();
			while (input != "END")
			{
				var arr = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
				var studentName = arr[1] + " " + arr[2];
				var facNumber = int.Parse(arr[0]);
				var student = new Student()
				{
					FacultyNumber = facNumber,
					Name = studentName
				};
				students.Add(student);
				input = Console.ReadLine();
			}
			students.Join(specialties,
				a => a.FacultyNumber,
				b => b.FacultyNumber,
				(a, b) => new {a.Name, a.FacultyNumber, b.SpecialtyName}
			).OrderBy(student => student.Name).ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.FacultyNumber} {x.SpecialtyName}"));

		}
	}

	public class Student
	{
		public string Name { get; set; }
		public int FacultyNumber { get; set; }
	}
	public class StudentSpecialty
	{
		public string SpecialtyName { get; set; }
		public int FacultyNumber { get; set; }
	}
}
