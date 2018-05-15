using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Vehicles
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double airConditionFuel;

    public Vehicles(double fuelQuantity, double fuelConsumption, double airConditionFuel)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumption = fuelConsumption;
        this.airConditionFuel = airConditionFuel;
    }

   
    public string Drive(double km)
    {
        var neededFuel = (this.fuelConsumption + airConditionFuel) * km;

        if (neededFuel > this.fuelQuantity)
        {
            return $"{this.GetType().Name} needs refueling";
        }

        this.fuelQuantity -= neededFuel;
        return $"{this.GetType().Name} travelled {km} km";
    }

    public virtual void Refuel(double fuel)
    {
        this.fuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {this.fuelQuantity:f2}";
    }
}

