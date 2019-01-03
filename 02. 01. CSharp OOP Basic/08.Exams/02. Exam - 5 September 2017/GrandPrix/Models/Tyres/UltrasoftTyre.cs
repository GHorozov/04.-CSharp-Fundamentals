using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        protected set { grip = value; }
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    public override void CompleteLap()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}

