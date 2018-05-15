using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterStudentsByPhone
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
    class FilterStudentsByPhone
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
                    Phone = line[2]
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }

            list
                .Where(p => p.Phone.StartsWith("02") || p.Phone.StartsWith("+3592"))
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));

        }
    }
}
