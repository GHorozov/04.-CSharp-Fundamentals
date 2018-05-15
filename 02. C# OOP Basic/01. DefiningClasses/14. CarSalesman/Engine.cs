using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    //An Engine has model, power, displacement and efficiency
    private string model;
    private int power;
    private string displacement= "n/a";
    private string efficiency = "n/a";

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        
    }
    
    public Engine(string model, int power, string displacement, string efficiency) : this( model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public int Power
    {
        get { return this.Power; }
        set { this.power = value; }
    }
    public string Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }
    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();
        strBuilder.AppendLine($"  {this.model}:");
        strBuilder.AppendLine($"    Power: {this.power}");
        strBuilder.AppendLine($"    Displacement: {this.displacement}");
        strBuilder.Append($"    Efficiency: {this.efficiency}");

        return strBuilder.ToString();
    }
}

