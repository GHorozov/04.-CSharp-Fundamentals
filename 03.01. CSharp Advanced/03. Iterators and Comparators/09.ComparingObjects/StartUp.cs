namespace _09.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var collection = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split();
                var newPerson = new Person(lineParts[0], int.Parse(lineParts[1]), lineParts[2]);
                collection.Add(newPerson);
            }

            var n = int.Parse(Console.ReadLine());
            var targetPerson = collection[n-1];

            var numberOfEqualPeople = collection.Count(x => x.CompareTo(targetPerson) == 0);
            var numberOfNotEqualPeople = collection.Count(x => x.CompareTo(targetPerson) != 0);
            var totalPeople = collection.Count;

            if(numberOfEqualPeople < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {totalPeople}");
            }
        }
    }
}
