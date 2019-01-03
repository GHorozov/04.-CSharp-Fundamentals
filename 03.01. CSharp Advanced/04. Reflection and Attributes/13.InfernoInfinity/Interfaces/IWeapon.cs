using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    string Name { get; }
    int MinDamage { get;}
    int MaxDamage { get; }
    int NumberOfSockets { get; }
    Rarity Rarity { get; }
    IGem[] Sockets { get; }
}

