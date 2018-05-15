using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByAge
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    class StudentsByAge
    {
        private const int minBound = 18;
        private const int maxBound = 24;

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
                    Age = int.Parse(line[2])
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }

            list
                .Where(s => s.Age >= minBound && s.Age <= maxBound)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName} {n.Age}"));
        }
    }
}
