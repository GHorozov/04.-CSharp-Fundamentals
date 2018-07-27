public class Car
{
    public string carModel;
    public string carSpeed;

    public Car(string carModel, string carSpeed)
    {
        this.carModel = carModel;
        this.carSpeed = carSpeed;
    }

    public override string ToString()
    {
        return $"{carModel} {carSpeed}";
    }
}