using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    private const double ConstDegradation = 100;

    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Degradation = ConstDegradation;
        this.Hardness = hardness;
    }


    public string Name { get; protected set; }
    public double Hardness { get; protected set; }

    public virtual double Degradation
    {
        get
        {
            return this.degradation;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void CurrentLapDropDagradation()
    {
        this.Degradation -= this.Hardness;
    }
}

