using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        SortedSet<Person> collection1 = new SortedSet<Person>();
        HashSet<Person> collection2 = new HashSet<Person>(new EqualityComperator());

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var inputParams = Console.ReadLine().Split(' ');

            collection1.Add(new Person(inputParams[0], int.Parse(inputParams[1])));
            collection2.Add(new Person(inputParams[0], int.Parse(inputParams[1])));
        }

        Console.WriteLine(collection1.Count);
        Console.WriteLine(collection2.Count);
    }
}
