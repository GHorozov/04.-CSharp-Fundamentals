using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private const double ConstFuelTank = 160;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get;protected set; }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        protected set
        {
            if(value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = Math.Min(value, ConstFuelTank);
        }
    }

    public Tyre Tyre { get;protected set; }

    public void ReduceFuelAmount(double fuel)
    {
        this.FuelAmount -= fuel;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }
}

