using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var rank = Console.ReadLine();
        var suit = Console.ReadLine();

        var card = new Card(rank, suit);

        Console.WriteLine(card);
    }
}

