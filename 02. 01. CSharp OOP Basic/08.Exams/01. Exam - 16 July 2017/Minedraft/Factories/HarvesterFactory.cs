using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester GetHarvester(List<string> inputParams)
    {
        var type = inputParams[0];
        var id = inputParams[1];
        var oreOutput = double.Parse(inputParams[2]);
        var energyRequirement = double.Parse(inputParams[3]);

        switch (type)
        {
            case "Sonic":
                var sonicFactor = int.Parse(inputParams[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                throw new InvalidOperationException();
        }
    }
}

