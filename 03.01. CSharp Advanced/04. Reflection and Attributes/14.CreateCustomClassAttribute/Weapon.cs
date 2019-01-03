using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon 
{
    public Weapon(string name, string rarity)
    {
        this.Name = name;
        this.MinDamage = 0;
        this.MaxDamage = 0;
        this.NumberOfSockets = 0;
    }

    public string Name { get; protected set; }
    public int MinDamage { get; protected set; }
    public int MaxDamage { get; protected set; }
    public int NumberOfSockets { get; protected set; }

    public override string ToString()
    {
        var result = $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage";

        return result;
    }
}

