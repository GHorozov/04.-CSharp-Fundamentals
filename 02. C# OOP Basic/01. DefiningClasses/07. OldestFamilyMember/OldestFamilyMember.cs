using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class OldestFamilyMember
{
    static void Main(string[] args)
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        var family = new Family();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(' ');
            var name = lineParts[0];
            var age = int.Parse(lineParts[1]);

            var newPerson = new Person(name, age);

            family.AddMember(newPerson);
        }

        var oldest = family.GetOldestMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");

    }
}

