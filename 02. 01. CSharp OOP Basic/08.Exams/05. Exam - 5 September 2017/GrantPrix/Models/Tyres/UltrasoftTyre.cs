using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private const string ConstName = "Ultrasoft";

    public UltrasoftTyre(double hardness, double grip)
        : base(ConstName, hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; protected set; }

    public override double Degradation
    {
        get
        {
            return base.Degradation;
        }
        protected set
        {
            if(value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    public override void CurrentLapDropDagradation()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}

