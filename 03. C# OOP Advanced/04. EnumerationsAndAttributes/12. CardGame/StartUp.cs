using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    private static Card biggestCard;
    private static string winner;

    public static void Main(string[] args)
    {
        var firstPlayer = Console.ReadLine();
        var secondPlayer = Console.ReadLine();

        var deck = GenerateDeck();
        var firstPlayerDeck = new List<Card>();
        var secondPlayerDeck = new List<Card>();

        while (firstPlayerDeck.Count < 5 || secondPlayerDeck.Count < 5)
        {
            var line = Console.ReadLine().Split(' ');
            var lineRank = line[0];
            var lineSuit = line[2];


            try
            {
                var card = new Card(lineRank, lineSuit);

                if (deck.Contains(card))
                {
                    deck.Remove(card);

                    if (firstPlayerDeck.Count < 5)
                    {
                        firstPlayerDeck.Add(card);
                        WinnerCheck(card, firstPlayer);
                    }
                    else
                    {
                        secondPlayerDeck.Add(card);
                        WinnerCheck(card, secondPlayer);
                    }

                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("No such card exists.");
            }
        }

        Console.WriteLine($"{winner} wins with {biggestCard}.");
    }

    private static void WinnerCheck(Card card, string firstPlayer)
    {
        if (card.CompareTo(biggestCard) > 0)
        {
            biggestCard = card;
            winner = firstPlayer;
        }
    }

    private static List<Card> GenerateDeck()
    {
        var deck = new List<Card>();

        foreach (var cardSuit in Enum.GetNames(typeof(Suit)))
        {
            foreach (var cardRank in Enum.GetNames(typeof(Rank)))
            {
                var card = new Card(cardRank, cardSuit);
                deck.Add(card);
            }
        }

        return deck;
    }
}