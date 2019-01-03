using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var value = double.Parse(this.Arguments[0]);
        var result = this.ProviderController.Repair(value);

        return result;
    }
}

