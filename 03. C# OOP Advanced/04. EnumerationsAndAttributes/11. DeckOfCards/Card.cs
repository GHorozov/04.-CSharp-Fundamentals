using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card : IComparable<Card>
{
    public Rank CardRank { get; protected set; }
    public Suit CardSuit { get; protected set; }

    public Card(string rank, string suit)
    {
        this.CardRank = (Rank)Enum.Parse(typeof(Rank), rank);
        this.CardSuit = (Suit)Enum.Parse(typeof(Suit), suit);
    }

    public int ReturnPowerOfCard()
    {
        return ((int)this.CardRank + (int)this.CardSuit);
    }

    public int CompareTo(Card other)
    {
        var result = this.ReturnPowerOfCard().CompareTo(other.ReturnPowerOfCard());

        return result;
    }

    public override string ToString()
    {
        return $"{Enum.GetName(typeof(Rank), CardRank)} of {Enum.GetName(typeof(Suit), CardSuit)}";
    }
}

