using System;

public class Car
{
    public string model;
    public decimal fuelAmount;
    public decimal fuelExpence;
    public decimal distance;

    public Car(string model, decimal fuelAmount, decimal fuelExpence)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelExpence = fuelExpence;
    }


    public void Drive(decimal amountOfKm)
    {
        var travelRange = fuelAmount / fuelExpence;

        if(travelRange < amountOfKm)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            distance += amountOfKm;
            fuelAmount -= (amountOfKm * fuelExpence); 
        }
    }


    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.distance}";
    }
}

