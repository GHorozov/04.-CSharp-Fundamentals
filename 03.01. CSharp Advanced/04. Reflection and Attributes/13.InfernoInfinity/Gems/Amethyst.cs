using System;
using System.Collections.Generic;
using System.Text;

public class Amethyst : Gem
{
    private const int STRENGTH = 2;
    private const int AGILITY = 8;
    private const int VITALITY = 4;

    public Amethyst(string clarity) 
        : base(clarity)
    {
        this.Strength = STRENGTH;
        this.Agility = AGILITY;
        this.Vitality = VITALITY;
        IncreaseByClarity(this.Clarity);
    }
}

