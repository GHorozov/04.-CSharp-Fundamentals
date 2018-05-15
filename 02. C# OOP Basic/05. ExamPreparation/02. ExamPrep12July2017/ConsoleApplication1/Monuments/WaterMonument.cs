using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }
    public int WaterAffinity
    {
        get { return this.waterAffinity; }
        private set { this.waterAffinity = value; }         
    }
     
    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }
    public override string ToString()
    {
        return $"###Water Monument: {base.ToString()}, Water Affinity: {this.WaterAffinity}";
    }

    
}

