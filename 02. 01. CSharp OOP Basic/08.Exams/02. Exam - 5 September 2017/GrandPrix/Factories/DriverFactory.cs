using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    private TyreFactory tyreFactory = new TyreFactory();

    public Driver CreateDriver(List<string> args)
    {
        var type = args[0];
        var driverName = args[1];
        var hp = int.Parse(args[2]);
        var fuelAmount = double.Parse(args[3]);

        Tyre newTyre;
        Car newCar;
        switch (type)
        {
            case "Aggressive":
                newTyre = tyreFactory.CreateTyre(args.Skip(4).ToList());
                newCar = new Car(hp, fuelAmount, newTyre);
                return new AggressiveDriver(driverName, newCar);

            case "Endurance":
                newTyre = tyreFactory.CreateTyre(args.Skip(4).ToList());
                newCar = new Car(hp, fuelAmount, newTyre);
                return new EnduranceDriver(driverName,newCar);

            default:
                throw new InvalidOperationException();
        }
    }
}

