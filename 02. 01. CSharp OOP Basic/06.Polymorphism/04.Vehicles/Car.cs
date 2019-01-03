public class Car : Vihicle
{
    private const double AirConditionConsumptionIncrease = 0.9;

    public Car(double fuelQuantity, double fuelConsumption )
        :base(fuelQuantity, fuelConsumption += AirConditionConsumptionIncrease)
    {
    }
    
    public override void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }
}

