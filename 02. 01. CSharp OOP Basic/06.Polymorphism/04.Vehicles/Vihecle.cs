using System;

public abstract class Vihicle : IVehicle
{
    public Vihicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }

    public virtual string DriveCar(double distance)
    {
        var drivingDistance = this.FuelQuantity / this.FuelConsumption;
        if (drivingDistance >= distance)
        {
            this.FuelQuantity -= (distance * this.FuelConsumption);
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }

    public abstract void Refuel(double fuel);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

