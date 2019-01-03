using System;
using System.Collections.Generic;
using System.Text;

public class Light
{
    public Light(string traficLight)
    {
        this.TraficLight = Enum.Parse<TrafficLights>(traficLight);
    }

    public TrafficLights TraficLight { get; private set; }


    public void Change()
    {
        this.TraficLight++;

        if((int)this.TraficLight > 2)
        {
            this.TraficLight = 0;
        }
    }

    public override string ToString()
    {
        return $"{this.TraficLight}";
    }
}

