using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class SortStudents
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
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, list
                 .OrderBy(st => st.LastName)
                 .ThenByDescending(st => st.FirstName)
                 .Select(st => $"{st.FirstName} {st.LastName}")));
        }
    }
}
