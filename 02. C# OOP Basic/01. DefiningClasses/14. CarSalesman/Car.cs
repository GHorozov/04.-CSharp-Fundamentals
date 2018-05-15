using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    private string model;
    private Engine engine;
    private string weight = "n/a";
    private string color = "n/a";

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;

    }

    public Car(string model, Engine engine, string weight, string color) : this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public string Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }
    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"{this.engine.ToString()}");
        sb.AppendLine($"  Weight: {this.weight}");
        sb.Append($"  Color: {this.color}");

        return sb.ToString();
    }
}

