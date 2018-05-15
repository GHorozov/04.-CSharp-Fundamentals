﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get
        {
            return this.waterClarity;
        }
        private set
        {
            this.waterClarity = value;
        }
    }

    public override double GetTotalPower()
    {
        return base.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"###Water Bender: {base.ToString()}, Water Clarity: {this.WaterClarity:f2}";
    }
}

