using System;

public class Bus : Vehicle
{
    private const double AirConditionConsumptionIncrease = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double fuelTankCapacity) 
        : base(fuelQuantity, fuelConsumption, fuelTankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        var drivingDistance = this.FuelQuantity / (this.FuelConsumption + AirConditionConsumptionIncrease);
        if (drivingDistance >= distance)
        {
            this.FuelQuantity -= (distance * (this.FuelConsumption + AirConditionConsumptionIncrease));
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }

    public override string DriveWithoutAirCondition(double distance)
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

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if ((fuel + this.FuelQuantity) > this.FuelTankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }

        this.FuelQuantity += fuel;
    }
}

