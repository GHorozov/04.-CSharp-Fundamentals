using System;
using System.Text;

public abstract class Driver 
{
    private const double BOX_TIME = 20;
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private bool isOutOfTheRace;
    private string failureReason;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0d;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.IsOutOfTheRace = false;
        this.FailureReason = string.Empty;
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        protected set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }
    
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsOutOfTheRace
    {
        get { return this.isOutOfTheRace; }
        protected set
        {
            this.isOutOfTheRace = value;
        }
    }

    public string FailureReason
    {
        get { return this.failureReason; }
        set
        {
            this.failureReason = value;
        }
    }

    public void AddFuel(double fuelAmount)
    {
        Box();
        this.Car.AddFuel(fuelAmount);
    }

    public void ChangeTyre(Tyre newTyre)
    {
        Box();
        this.Car.ChangeTyre(newTyre);
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);

        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    private void Box()
    {
        this.TotalTime += BOX_TIME;
    }

    //--------------------------
    public void IncreaseTotalTimeBySeconds(double sec)
    {
        this.TotalTime += sec;
    }
    public void DecreaseTotalTimeBySeconds(double sec)
    {
        this.TotalTime -= sec;
    }

    public void Fail(string message)
    {
        this.IsOutOfTheRace = true;
        this.FailureReason = message;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (this.IsOutOfTheRace)
        {
            sb.AppendLine($"{this.Name} {this.FailureReason}");
        }
        else
        {
            sb.AppendLine($"{this.Name} {this.TotalTime:f3}");
        }

        return sb.ToString().TrimEnd();
    }
}