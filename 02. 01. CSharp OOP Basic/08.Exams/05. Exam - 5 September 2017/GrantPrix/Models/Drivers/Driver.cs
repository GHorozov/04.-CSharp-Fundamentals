using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0d;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.IsOutOfRace = false;
        this.ReasonToFail = string.Empty;
    }

    public string Name { get; protected set; }
    public double TotalTime { get; protected set; }
    public Car Car { get; protected set; }
    public double FuelConsumptionPerKm { get; protected set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsOutOfRace { get;protected set; }
    public string ReasonToFail { get;protected set; }

    public void IncreaseTotalTime(double time)
    {
        this.TotalTime += time;
    }

    public void GetDriverOutOfRace()
    {
        this.IsOutOfRace = true;
    }

    public void SetReasonToFail(string reason)
    {
        this.ReasonToFail = reason;
    }

    public void DecreaseTotalTime(double time)
    {
        this.TotalTime -= time;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (this.IsOutOfRace)
        {
            sb.AppendLine($"{this.Name} {this.ReasonToFail}");
        }
        else
        {
            sb.AppendLine($"{this.Name} {this.TotalTime:f3}");
        }

        return sb.ToString().TrimEnd();
    }
}

