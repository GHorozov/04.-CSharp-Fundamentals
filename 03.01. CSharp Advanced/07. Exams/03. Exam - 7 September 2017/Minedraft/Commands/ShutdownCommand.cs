using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) 
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var providersTotalEnergyProduced = this.ProviderController.TotalEnergyProduced;
        var harvesterTotalOreProduced = this.HarvesterController.OreProduced;

        return string.Format(Constants.ShutDownResult, providersTotalEnergyProduced, harvesterTotalOreProduced);
    }
}

