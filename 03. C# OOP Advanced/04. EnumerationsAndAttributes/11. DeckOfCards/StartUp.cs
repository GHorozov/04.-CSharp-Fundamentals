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
        var deck = new List<Card>();

        foreach (var cardSuit in Enum.GetNames(typeof(Suit)))
        {
            foreach (var cardRank in Enum.GetNames(typeof(Rank)))
            {
                var card = new Card(cardRank, cardSuit);
                deck.Add(card);
            }
        }

        foreach (var card in deck)
        {
            Console.WriteLine(card);
        }
    }
}
