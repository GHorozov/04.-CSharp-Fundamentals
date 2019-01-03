using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{
    private const double ConstFuelConsumptionPerKm = 2.7;
    private const double ConstSpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, ConstFuelConsumptionPerKm)
    {
    }

    public override double Speed => base.Speed * ConstSpeedMultiplier;
}

