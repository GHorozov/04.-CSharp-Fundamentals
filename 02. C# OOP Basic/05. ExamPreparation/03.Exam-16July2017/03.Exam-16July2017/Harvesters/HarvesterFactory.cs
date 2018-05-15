using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester Get(List<string> arguments)
    {
        string type = arguments[1];
        string id = arguments[2];
        double oreOutput = double.Parse(arguments[3]);
        double energyRequirement = double.Parse(arguments[4]);

        if (type == "Sonic")
        {
            return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(arguments[5]));
        }
        else
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
    }
}
    

