using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation ) : base(name,power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return this.groundSaturation; }
        private set { this.groundSaturation = value; }
    }
    public override double GetTotalPower()
    {
        return base.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"###Earth Bender: {base.ToString()}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}
