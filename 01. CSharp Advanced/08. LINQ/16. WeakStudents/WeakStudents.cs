using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Grades { get; set; }
    }
    class WeakStudents
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
                    Grades = line.Skip(2).Select(s => s).ToList()
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }

            list
                 .Where(x => x.Grades.Count(mark => int.Parse(mark) <= 3) >= 2) //Check if count <= 3 marks in grades and if count >= 2 return
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
           
        }
    }
}
