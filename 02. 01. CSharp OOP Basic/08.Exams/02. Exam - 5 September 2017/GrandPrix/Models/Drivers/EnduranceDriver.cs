using System;

public class EnduranceDriver : Driver
{
    private const double FUEL_CONSUMPTION_CONST = 1.5;

    public EnduranceDriver(string name, Car Car) 
        : base(name, Car, FUEL_CONSUMPTION_CONST)
    {
    }
}

