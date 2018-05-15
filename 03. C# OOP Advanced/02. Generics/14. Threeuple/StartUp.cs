using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var first = Console.ReadLine().Split(' ');
        var second = Console.ReadLine().Split(' ');
        var thirth = Console.ReadLine().Split(' ');

        Console.WriteLine(new Threeuple<string, string, string>(first[0] + " " + first[1], first[2], first[3]));

        if (second[2] == "drunk")
        {
            Console.WriteLine(new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), true));
        }
        else
        {
            Console.WriteLine(new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), false));
        }

        Console.WriteLine(new Threeuple<string, double, string>(thirth[0], double.Parse(thirth[1]), thirth[2]));
    }
}

