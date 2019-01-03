using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider GetProvider(List<string> inputParams)
    {
        var type = inputParams[0];
        var id = inputParams[1];
        var energyOutput = double.Parse(inputParams[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                throw new InvalidOperationException();
        }
    }
}

