using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double fuelTankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double fuelTankCapacity)
    {
        this.FuelTankCapacity = fuelTankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        set
        {
            if(value > this.fuelTankCapacity)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }

    public double FuelConsumption
    {
        get
        {
            return this.fuelConsumption;
        }
        set
        {

            this.fuelConsumption = value;
        }
    }

    public double FuelTankCapacity
    {
        get
        {
            return this.fuelTankCapacity;
        }
        set
        {
            this.fuelTankCapacity = value;
        }
    }

    public abstract string Drive(double distance);

    public virtual string DriveWithoutAirCondition(double distance)
    {
        return string.Empty;
    }

    public abstract void Refuel(double fuel);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

