using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
    public Gem(string clarity)
    {
        this.Strength = 0;
        this.Agility = 0;
        this.Vitality = 0;
        this.Clarity = GetClarity(clarity);
    }

    public int Strength { get; protected set; }
    public int Agility { get; protected set; }
    public int Vitality { get; protected set; }
    public virtual Clarity Clarity { get; protected set; }

    protected virtual Clarity GetClarity(string clarity)
    {
        Clarity gemClarity;
        bool isValid = Enum.TryParse<Clarity>(clarity, out gemClarity);
        if (!isValid)
        {
            throw new InvalidOperationException("Invalid clarity input!");
        }

        return gemClarity;
    }

    protected virtual void IncreaseByClarity(Clarity clarity)
    {
        this.Strength += (int)clarity;
        this.Agility += (int)clarity;
        this.Vitality += (int)clarity;
    }
}

