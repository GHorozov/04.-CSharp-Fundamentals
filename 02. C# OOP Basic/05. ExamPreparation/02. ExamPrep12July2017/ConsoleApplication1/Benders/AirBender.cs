﻿using System;
using System.Text;

public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity ) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get
        {
            return this.aerialIntegrity;
        }
        private set
        {
            this.aerialIntegrity = value;
        }
    }

    public override double GetTotalPower()
    {
        return base.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"###Air Bender: {base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}

