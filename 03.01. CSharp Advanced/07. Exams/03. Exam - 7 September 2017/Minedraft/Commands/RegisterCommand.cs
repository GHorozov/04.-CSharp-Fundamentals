using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var harvesterOrProvider = this.Arguments[0];
        var args = this.Arguments.Skip(1).ToList();

        if (harvesterOrProvider == "Harvester")
        {
            return  this.HarvesterController.Register(args);
        }
        else if(harvesterOrProvider == "Provider")
        {
            return this.ProviderController.Register(args);
        }

        return "Invalid Entity to Register";
    }
}

