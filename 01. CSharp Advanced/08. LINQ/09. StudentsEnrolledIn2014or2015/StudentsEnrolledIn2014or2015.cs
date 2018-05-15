using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsEnrolledIn2014or2015
{
    class StudentsEnrolledIn2014or2015
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var list = new List<string[]>();
            while (input != "END")
            {
                var line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(line);
                input = Console.ReadLine();
            }

            list
                .Where(arr => arr[0].EndsWith("14") || arr[0].EndsWith("15"))
                .ToList()
                .ForEach(n => Console.WriteLine($"{string.Join(" ", n.Skip(1))}"));

        }
    }
}
