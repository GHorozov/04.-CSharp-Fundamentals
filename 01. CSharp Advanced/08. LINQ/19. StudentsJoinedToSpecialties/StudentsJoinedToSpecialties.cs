using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsJoinedToSpecialties
{
    public class StudentSpecialty
    {
        public string SpecialtyName  { get; set; }
        public int FacultyNumber { get; set; }

        public StudentSpecialty(string name, int num)
        {
            this.SpecialtyName = name;
            this.FacultyNumber = num;
        }
    }

    public class Student
    {
        public string StudentName { get; set; }
        public int FacultyNumber { get; set; }

        public Student(string name, int num)
        {
            this.StudentName = name;
            this.FacultyNumber = num;
        }
    }
    class StudentsJoinedToSpecialties
    {
        static void Main(string[] args)
        {
            var specs = new List<StudentSpecialty>();
            var students = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "Students:")
            {
                var lineParts = input.Split(' ');
                specs.Add(new StudentSpecialty(lineParts[0]+" "+ lineParts[1], int.Parse(lineParts[2])));
            }
            
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split(' ');
                students.Add(new Student(lineParts[1]+ " "+ lineParts[2], int.Parse(lineParts[0])));
            }

            //Joint specs list with students list. Take common facultyNumber for both and create new anonymous object with all three params.
            specs.Join(students, sp => sp.FacultyNumber, st => st.FacultyNumber, (sp, st) => new
            {
                Name = st.StudentName,
                FacNum = sp.FacultyNumber,
                Spec = sp.SpecialtyName
            })
            .OrderBy(res => res.Name)
            .ToList()
            .ForEach(res => Console.WriteLine($"{res.Name} {res.FacNum} {res.Spec}"));

        }
    }
}
