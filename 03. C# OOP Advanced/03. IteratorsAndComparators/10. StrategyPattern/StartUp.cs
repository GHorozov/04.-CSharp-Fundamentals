using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        SortedSet<Person> collection1 = new SortedSet<Person>(new PersonCompareByName());
        SortedSet<Person> collection2 = new SortedSet<Person>(new PersonCompareByAge());

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var inputParams = Console.ReadLine().Split(' ');

            collection1.Add(new Person(inputParams[0], int.Parse(inputParams[1])));
            collection2.Add(new Person(inputParams[0], int.Parse(inputParams[1])));
        }

        var equalName = collection1.Select(x => x.Name.CompareTo(x.Name));

        Console.WriteLine(string.Join(Environment.NewLine, collection1));
        Console.WriteLine(string.Join(Environment.NewLine, collection2));
    }
}

