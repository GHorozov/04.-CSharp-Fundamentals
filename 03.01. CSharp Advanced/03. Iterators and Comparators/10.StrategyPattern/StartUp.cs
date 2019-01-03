namespace _10.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSetByNames = new SortedSet<Person>(new PersonCompatorByNames());
            var sortedSetByAge = new SortedSet<Person>(new PersonComparatorByAge());

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var lineParts = Console.ReadLine().Split();
                var name = lineParts[0];
                var age = int.Parse(lineParts[1]);

                var newPerson = new Person(name, age);
                sortedSetByNames.Add(newPerson);
                sortedSetByAge.Add(newPerson);
            }

            foreach (var person in sortedSetByNames)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in sortedSetByAge)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
