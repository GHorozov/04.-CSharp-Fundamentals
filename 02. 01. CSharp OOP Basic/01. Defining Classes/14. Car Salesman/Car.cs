using System.Text;

internal class Car
{
    public string model;
    public Engine engine;
    public string weight = "n/a";
    public string color = "n/a";

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public Car(string model, Engine engine, string weight, string color):this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"    {this.engine.ToString()}");
        sb.AppendLine($"    Weight: {this.weight}");
        sb.AppendLine($"    Color: {this.color}");

        return sb.ToString().TrimEnd();
    }
}