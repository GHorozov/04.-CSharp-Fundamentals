using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Seat : ICar
{
    private string color;
    private string model;

    public Seat(string model, string color)
    {
        this.Color = color;
        this.Model = model;
    }
    public string Color { get; }
    

    public string Model { get; }
   

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
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model}");

        return sb.ToString().Trim();
    }
}

