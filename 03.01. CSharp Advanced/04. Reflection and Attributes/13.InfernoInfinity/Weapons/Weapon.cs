using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Weapon : IWeapon
{
    public Weapon(string name, string rarity)
    {
        this.Name = name;
        this.MinDamage = 0;
        this.MaxDamage = 0;
        this.NumberOfSockets = 0;
        this.Rarity = GetRarity(rarity);
    }

    public string Name { get; protected set; }
    public int MinDamage { get; protected set; }
    public int MaxDamage { get; protected set; }
    public int NumberOfSockets { get; protected set; }
    public Rarity Rarity { get; protected set; }
    public IGem[] Sockets { get; protected set; }

    protected Rarity GetRarity(string rarity)
    {
        Rarity weaponRarity;
        var isValid = Enum.TryParse<Rarity>(rarity, out weaponRarity);
        if (!isValid)
        {
            throw new InvalidOperationException("Rarity is invalid!");
        }

        return weaponRarity;
    }

    protected virtual void IncreaseByRarity(Rarity rarity)
    {
        this.MinDamage *= (int)rarity;
        this.MaxDamage *= (int)rarity;
    }

    public virtual void IncreaseByGemsStats()
    {
        for (int i = 0; i < this.Sockets.Length; i++)
        {
            var gem = this.Sockets[i];
            if (gem != null)
            {
                this.MinDamage += gem.Strength * 2;
                this.MaxDamage += gem.Strength * 3;
                this.MinDamage += gem.Agility * 1;
                this.MaxDamage += gem.Agility * 4;
            }
        }
    }

    public override string ToString()
    {
        this.IncreaseByRarity(this.Rarity);
        this.IncreaseByGemsStats();

        var totalStrength = 0;
        var totalAgility = 0;
        var totalVitality = 0;
        for (int i = 0; i < this.Sockets.Length; i++)
        {
            var gem = this.Sockets[i];
            if (gem != null)
            {
                totalStrength += gem.Strength;
                totalAgility += gem.Agility;
                totalVitality += gem.Vitality;
            }
        }

        var result = $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";

        return result;
    }
}

