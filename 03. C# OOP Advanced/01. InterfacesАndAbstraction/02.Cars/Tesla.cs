using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tesla : ICar, IElectricCar
{

    public Tesla(string model, string color, int battery)
    {
        this.Battery = battery;
        this.Model = model;
        this.Color = color;
    }
    public int Battery { get; }
    public string Model { get; }
    public string Color { get; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries");

        return sb.ToString().Trim();
    }
}

