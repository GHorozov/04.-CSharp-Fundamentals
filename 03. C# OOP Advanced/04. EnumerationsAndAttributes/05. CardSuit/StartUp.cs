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
        var cards = Enum.GetValues(typeof(CardSuit));

        Console.WriteLine($"{input}:");
        foreach (var card in cards)
        {
            Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
        }
    }
}

