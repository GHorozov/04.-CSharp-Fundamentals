using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return hp; }
        protected set { hp = value; }
    }
    
    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException($"Out of fuel");
            }

            if(value > 160)
            {
                this.fuelAmount = 160;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyre Tyre
    {
        get { return tyre; }
        protected set { tyre = value; }
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void AddFuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void CompleteLap(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;

        this.Tyre.CompleteLap();
    }
}

