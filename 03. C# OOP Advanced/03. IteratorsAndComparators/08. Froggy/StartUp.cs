using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake<int> lake = new Lake<int>(input);

        Console.WriteLine(string.Join(", ", lake));
    }
}

