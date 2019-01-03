using System;
using System.Collections.Generic;
using System.Text;

public class ReportUnitCommand : Command
{
    public ReportUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        string output = this.Repository.Statistics;
        return output;
    }
}

