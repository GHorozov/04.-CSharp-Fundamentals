using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var firstLine = Console.ReadLine().Split(' ');
        var tuple1 = new Tuple<string, string>(firstLine[0]+ " " + firstLine[1], firstLine[2]);
        Console.WriteLine(tuple1);

        var secondLine = Console.ReadLine().Split(' ');
        var tuple2 = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));
        Console.WriteLine(tuple2);

        var thirthLine = Console.ReadLine().Split(' ');
        var tuple3 = new Tuple<int, double>(int.Parse(thirthLine[0]), double.Parse(thirthLine[1]));
        Console.WriteLine(tuple3);
    }
}
