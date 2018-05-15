using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellentStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Grades { get; set; }
    }
    class ExcellentStudents
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var list = new List<Student>();
            while (input != "END")
            {
                var line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var newStudent = new Student
                {
                    FirstName = line[0],
                    LastName = line[1],
                    Grades = line.Skip(2).ToList()
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }


            list
                .Where(x => x.Grades.Contains("6"))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
