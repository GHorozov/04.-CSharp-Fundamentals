using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider RegisterProvider(List<string> arguments)
    {
        var type = arguments[1];
        var id = arguments[2];
        var energyOutput = double.Parse(arguments[3]);

        if (type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else 
        {
            return new PressureProvider(id, energyOutput);
        }
    }
}

