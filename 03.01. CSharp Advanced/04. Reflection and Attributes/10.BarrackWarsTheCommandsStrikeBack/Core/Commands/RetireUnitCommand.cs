using System;
using System.Collections.Generic;
using System.Text;

public class RetireUnitCommand : Command
{
    public RetireUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        var unitType = this.Data[1];
        this.Repository.RemoveUnit(unitType);
        string output = unitType + " retired!";
        return output;
    }
}

