public class Truck : Vihicle
{
    private const double AirConditionConsumptionIncrease = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption += AirConditionConsumptionIncrease)
    {
    }

    public override void Refuel(double fuel)
    {
        var fuelToAdd = fuel * 0.95;
        this.FuelQuantity += fuelToAdd;
    }
}

