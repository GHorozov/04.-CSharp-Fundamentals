using System;

public class AggressiveDriver : Driver
{
    private const double FUEL_CONSUMPTION_CONST = 2.7;
    private const double SPEED_MYLTIPLIER_CONST = 1.3;

    public AggressiveDriver(string name, Car Car) 
        : base(name, Car, FUEL_CONSUMPTION_CONST)
    {
    }

    public override double Speed => base.Speed * SPEED_MYLTIPLIER_CONST;

}

