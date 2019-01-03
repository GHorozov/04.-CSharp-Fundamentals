using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
    private const int STRENGTH = 1;
    private const int AGILITY = 4;
    private const int VITALITY = 9;

    public Emerald(string clarity) 
        : base(clarity)
    {
        this.Strength = STRENGTH;
        this.Agility = AGILITY;
        this.Vitality = VITALITY;
        IncreaseByClarity(this.Clarity);
    }
}

