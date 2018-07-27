using System;

class OldestFamilyMember
{
    static void Main(string[] args)
    {
        var family = new Family();
        var n = int.Parse(Console.ReadLine());
    
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            var person = new Person(name, age);
            family.AddMember(person);
        }

        var oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

