using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGraduation
{
    class AcademyGraduation
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                var averageGrade = grades.Average();

                if (!students.ContainsKey(name))
                {
                    students.Add(name, averageGrade);
                }

                students[name] = averageGrade;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value}");
            }
        }
    }
}
