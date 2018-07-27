using System;
using System.Collections.Generic;
using System.Linq;

class OpinionPoll
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var listPeople = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            var lineArgs = Console.ReadLine().Split();
            var name = lineArgs[0];
            var age = int.Parse(lineArgs[1]);

            listPeople.Add(new Person(name, age));
        }

        foreach (var person in listPeople.OrderBy(x => x.name))
        {
            if (person.IsOlderBy30(person))
            {
                Console.WriteLine($"{person.name} - {person.age}");
            }
        }

    }
}

