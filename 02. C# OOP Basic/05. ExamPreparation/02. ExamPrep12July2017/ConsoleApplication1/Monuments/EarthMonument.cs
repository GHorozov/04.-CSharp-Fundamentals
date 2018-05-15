using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthMonument : Monument
{
    private int earthAffinity;
   
    public EarthMonument(string name, int earthAffinity ) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }
    public int EarthAffinity
    {
        get { return this.earthAffinity; }
        private set { this.earthAffinity = value; }
    }
    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }
    public override string ToString()
    {
        return $"###Earth Monument: {base.ToString()}, Earth Affinity: {this.EarthAffinity}";
    }
}

