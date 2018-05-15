using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterStudentsByEmailDomain
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    class FilterStudentsByEmailDomain
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
                    Email = line[2]
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }


            list.Where(e => e.Email.EndsWith("@gmail.com"))
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }
}
