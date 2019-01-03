using System;
using System.Collections.Generic;
using System.Text;

public class ReportUnitCommand : Command
{
    [Inject]
    private IRepository repository;
   
    public ReportUnitCommand(string[] data) 
        : base(data)
    {
    }

    public override string Execute()
    {
        string output = this.repository.Statistics;
        return output;
    }
}

