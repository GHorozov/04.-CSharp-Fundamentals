using System;
using System.Text;

public class Tesla : ICar, IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Model { get => model; set => model = value; }
    public string Color { get => color; set => color = value; }
    public int Battery { get => battery; set => battery = value; }

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
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine($"{Start()}");
        sb.AppendLine($"{Stop()}");

        return sb.ToString().TrimEnd();
    }
}

