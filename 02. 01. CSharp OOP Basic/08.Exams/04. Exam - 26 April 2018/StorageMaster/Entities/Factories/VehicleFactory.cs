using System;
using System.Collections.Generic;
using System.Text;

public class VehicleFactory
{
    public Vehicle CreateVehicle(string type)
    {
        var vehicleType = Type.GetType(type);
        if(vehicleType == null || type == "Vehicle")
        {
            throw new InvalidOperationException("Invalid vehicle type!");
        }

        Vehicle vehicle = null;
        try
        {
            vehicle = (Vehicle)Activator.CreateInstance(vehicleType);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.InnerException.Message);
        }

        return vehicle;
    }
}

