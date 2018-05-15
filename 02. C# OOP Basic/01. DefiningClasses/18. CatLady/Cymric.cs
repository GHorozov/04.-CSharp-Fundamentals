using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cymric : Cat
{
    public Cymric(string name, double furLength)
        : base(name)
    {
        this.FurLength = furLength;
        this.Type = "Cymric";
    }
    public double FurLength { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return $"{this.Type} {this.Name} {this.FurLength:f2}";
    }
}
