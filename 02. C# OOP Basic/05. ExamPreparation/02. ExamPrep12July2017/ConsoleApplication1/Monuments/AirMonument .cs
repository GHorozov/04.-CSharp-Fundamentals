﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirMonument : Monument
{
    private int airAffinity;
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return this.airAffinity; }
        private set { this.airAffinity = value; }
    }
    public override int GetAffinity()
    {
        return this.AirAffinity;
    }

    public override string ToString()
    {
        return $"###Air Monument: {base.ToString()}, Air Affinity: {this.AirAffinity}";
    }
}

