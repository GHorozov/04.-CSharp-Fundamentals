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

        var rank2= Console.ReadLine();
        var suit2 = Console.ReadLine();

        var card = new Card(rank, suit);
        var card2 = new Card(rank2,suit2);

        var listOfCards = new List<Card>();
        listOfCards.Add(card);
        listOfCards.Add(card2);

        Card bigger = listOfCards.OrderByDescending(x => x).First();
        Console.WriteLine(bigger);
    }
}

