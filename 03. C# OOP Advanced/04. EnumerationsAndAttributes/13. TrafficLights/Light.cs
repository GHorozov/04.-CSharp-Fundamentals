using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Light
{
    public Light(string light)
    {
        this.RtLight = (TrafficLights)Enum.Parse(typeof(TrafficLights), light);
    }

    public TrafficLights RtLight { get; protected set; }


    public void Change()
    {
        this.RtLight += 1;

        if((int)this.RtLight > 2)
        {
            this.RtLight = 0;
        }
    }

    public override string ToString()
    {
        return $"{this.RtLight}";
    }
}

