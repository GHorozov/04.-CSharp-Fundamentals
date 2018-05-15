using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OpinionPoll
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(' ');
            var name = lineParts[0];
            var age = int.Parse(lineParts[1]);

            var currentPerson = new Person(name, age);
            people.Add(currentPerson);
        }

        people
            .Where(x => x.Age > 30)
            .OrderBy(x => x.Name)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));

        
    }
}
