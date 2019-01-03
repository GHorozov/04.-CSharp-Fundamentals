using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    public DayCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();

        sb.AppendLine(this.ProviderController.Produce());
        sb.AppendLine(this.HarvesterController.Produce());

        return sb.ToString().TrimEnd();
    }
}

