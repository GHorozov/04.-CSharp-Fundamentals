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
        var ranks = Enum.GetValues(typeof(CardRank));

        Console.WriteLine($"{input}:");
        foreach (var rank in ranks)
        {
            Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
        }
    }
}
