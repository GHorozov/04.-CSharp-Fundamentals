using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Person> collection = new List<Person>();
        var input = Console.ReadLine();
        
        while(input != "END")
        {
            var line = input.Split(' ');

            collection.Add(new Person(line[0], int.Parse(line[1]), line[2]));

            input = Console.ReadLine();
        }

        var indexInput = int.Parse(Console.ReadLine());
        var person = collection[indexInput - 1];

        var numEqual = collection.Count(x => x.CompareTo(person) == 0);
        var numNotEqual = collection.Count(x => x.CompareTo(person)  != 0);

        Console.WriteLine(numEqual < 2 ? "No matches" : $"{numEqual} {numNotEqual} {collection.Count}");
    }
}

