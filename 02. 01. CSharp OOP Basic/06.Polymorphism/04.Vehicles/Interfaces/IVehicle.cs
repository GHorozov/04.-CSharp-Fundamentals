public interface IVehicle
{
    double FuelQuantity { get; set; }

    double FuelConsumption { get; set; }

    string DriveCar(double distance);

    void Refuel(double fuel);
}

