using System;
using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }

    public string Color
    {
        get
        {
            return color;
        }

        set
        {
            color = value;
        }
    }

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
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
        sb.AppendLine($"{Start()}");
        sb.AppendLine($"{Stop()}");

        return sb.ToString().TrimEnd(); 
    }
}

