using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

public class VehicleFactory
{
    public Vehicle CreateVehicle(string type)
    {
        Vehicle vehicle = null;
        if(type == "Van")
        {
            vehicle = new Van();
        }
        else if(type == "Semi")
        {
            vehicle = new Semi();
        }
        else if(type == "Truck")
        {
            vehicle = new Truck();
        }
        else
        {
            throw new InvalidOperationException("Invalid vehicle type!");
        }

        return vehicle;
    }
}

