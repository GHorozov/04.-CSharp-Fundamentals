using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Truck : Vehicles
{

    public Truck(double fuelQuantity, double fuelConsumption, double airConditionFuel) : base(fuelQuantity, fuelConsumption, airConditionFuel)
    {
    }

    public override void Refuel(double fuel)
    {
        var totalFuel= (fuel * 0.95);
        base.Refuel(totalFuel);
    }
}

