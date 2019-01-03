using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) 
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var mode = this.Arguments[0];
        var result = this.HarvesterController.ChangeMode(mode);

        return result;
    }
}

