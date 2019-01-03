using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Sword : Weapon
{
    private const int MinDamageConst = 4;
    private const int MaxDamageConst = 6;
    private const int NumberOfSocketsConst = 3;

    public Sword(string name, string rarity) 
        : base(name, rarity)
    {
        this.MinDamage = MinDamageConst;
        this.MaxDamage = MaxDamageConst;
        this.NumberOfSockets = NumberOfSocketsConst;
        this.Sockets = new IGem[NumberOfSockets];
    }
}

