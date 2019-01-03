using System;

public class VehicleFactory
{
    public Vehicle GetVehicle()
    {
        var input = Console.ReadLine().Split();
        var vehicleType = input[0];
        var fuelQuantity = double.Parse(input[1]);
        var fuelConsumption = double.Parse(input[2]);
        var fuelTankCapacity = double.Parse(input[3]);

        Vehicle vehicle = null;
        switch (vehicleType)
        {
            case "Car":
                vehicle = new Car(fuelQuantity, fuelConsumption, fuelTankCapacity);
                break;
            case "Truck":
                vehicle = new Truck(fuelQuantity, fuelConsumption, fuelTankCapacity);
                break;
            case "Bus":
                vehicle = new Bus(fuelQuantity, fuelConsumption, fuelTankCapacity);
                break;
            default:
                break;
        }

        return vehicle;
    }
}
