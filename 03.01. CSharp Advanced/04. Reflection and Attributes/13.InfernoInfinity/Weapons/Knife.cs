using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    private const int MinDamageConst = 3;
    private const int MaxDamageConst = 4;
    private const int NumberOfSocketsConst = 2;

    public Knife(string name, string rarity) 
        : base(name, rarity)
    {
        this.MinDamage = MinDamageConst;
        this.MaxDamage = MaxDamageConst;
        this.NumberOfSockets = NumberOfSocketsConst;
        this.Sockets = new IGem[NumberOfSockets];
    }
}

