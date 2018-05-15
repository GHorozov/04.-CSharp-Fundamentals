using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        if(input == "Rank")
        {
            PrintAttribute(typeof(Rank));
        }
        else if(input == "Suit")
        {
            PrintAttribute(typeof(Suit));
        }
    }

    private static void PrintAttribute(Type type)
    {
        var attributes = type.GetCustomAttributes(false);
        Console.WriteLine(attributes[0]);
    }
}
