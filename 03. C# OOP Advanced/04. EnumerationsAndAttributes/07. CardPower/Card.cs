using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    public Card()
    {

    }

    public int ReturnPowerOfCard(string rank, string suit)
    {
        Rank rankCard = (Rank)Enum.Parse(typeof(Rank), rank);
        Suit suitCard = (Suit)Enum.Parse(typeof(Suit), suit);

        return ((int)rankCard + (int)suitCard);
    }
}

