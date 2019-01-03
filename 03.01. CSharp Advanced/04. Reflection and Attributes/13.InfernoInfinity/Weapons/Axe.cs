using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Axe : Weapon
{
    private const int MinDamageConst = 5;
    private const int MaxDamageConst = 10;
    private const int NumberOfSocketsConst = 4;

    public Axe(string name, string rarity) 
        : base(name, rarity)
    {
        this.MinDamage = MinDamageConst;
        this.MaxDamage = MaxDamageConst;
        this.NumberOfSockets = NumberOfSocketsConst;
        this.Sockets = new IGem[NumberOfSocketsConst];
    }
}

