namespace _11.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSetCollection = new SortedSet<Person>(new PersonComparer());
            var hasSetCollection = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var lineParts = Console.ReadLine().Split();
                var name = lineParts[0];
                var age = int.Parse(lineParts[1]);

                var newPerson = new Person(name, age);
                sortedSetCollection.Add(newPerson);
                hasSetCollection.Add(newPerson);
            }

            Console.WriteLine(sortedSetCollection.Count);
            Console.WriteLine(hasSetCollection.Count);
        }
    }
}
