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

        var card = new Card();
    
        Console.WriteLine($"Card name: {rank} of {suit}; Card power: {card.ReturnPowerOfCard(rank, suit)}");
    }
}

