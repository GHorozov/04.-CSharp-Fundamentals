using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireBender : Bender
{
    private double heatAggression;
    

    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }
    public double HeatAggression
    {
        get
        {
            return this.heatAggression;
        }
        private set
        {
            this.heatAggression = value;
        }
    }
    public override double GetTotalPower()
    {
        return base.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"###Fire Bender: {base.ToString()}, Heat Aggression: {this.HeatAggression:f2}";
    }
}

