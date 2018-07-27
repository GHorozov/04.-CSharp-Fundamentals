using System.Text;

internal class Engine
{
    public string model;
    public int power;
    public string displacement = "n/a";
    public string efficiency = "n/a";

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
    }

    public Engine(string model, int power, string displacement,string efficiency) : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"        Power: {this.power}");
        sb.AppendLine($"        Displacement: {this.displacement}");
        sb.AppendLine($"        Efficiency: {this.efficiency}");

        return sb.ToString().TrimEnd(); 
    }
}