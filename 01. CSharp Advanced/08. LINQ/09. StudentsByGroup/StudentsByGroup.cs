using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    class StudentsByGroup
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
                .Where(arr => arr[2] == "2") //Filter only lines with last index is equal "2".
                .OrderBy(arr => arr[0]) //Order by first name.
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]}")); //Print first name and last name.
        }
    }
}
