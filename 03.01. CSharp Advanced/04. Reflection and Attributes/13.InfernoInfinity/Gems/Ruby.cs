using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{
    private const int STRENGTH = 7;
    private const int AGILITY = 2;
    private const int VITALITY = 5;

    public Ruby(string clarity) 
        : base(clarity)
    {
        this.Strength = STRENGTH;
        this.Agility = AGILITY;
        this.Vitality = VITALITY;
        IncreaseByClarity(this.Clarity);
    }
}

