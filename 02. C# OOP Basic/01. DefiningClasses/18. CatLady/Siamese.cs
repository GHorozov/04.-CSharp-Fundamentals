using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Siamese : Cat
{
    public Siamese(string name, long earSize)
        : base(name)
    {
        this.EarSize = earSize;
        this.Type = "Siamese";
    }

    public string Type { get; set; }
    public long EarSize { get; set; }

    public override string ToString()
    {
        return $"{this.Type} {this.Name} {this.EarSize}";
    }
}
