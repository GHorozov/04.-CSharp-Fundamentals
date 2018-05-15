using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    //Model, fuel amount, fuel consumption for 1 kilometer and distance traveled.
    private string model;
    private double amount;
    private double consumption= 0.00;
    private double distance;

    public Car(string model, double amount, double consumption)
    {
        this.model = model;
        this.amount = amount;
        this.consumption = consumption;
    }
    public Car(string model, double amount, double consumption, double distance) : this (model, amount, consumption)
    {
        this.distance = distance;
    }
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public double Amount
    {
        get { return this.amount; }
        set { this.amount = value; }
    }

    public double Distance
    {
        get { return this.distance; }
        set { this.distance = value; }
    }

    public void Drive(string carModel, double amountKm)
    {
        var fuelNeeded = amountKm * this.consumption;

        if(this.Amount < fuelNeeded)
        {
            Console.WriteLine("Insufficient fuel for the drive"); return;
        }

        this.Amount -= fuelNeeded;
        this.Distance += amountKm;
    }
}

