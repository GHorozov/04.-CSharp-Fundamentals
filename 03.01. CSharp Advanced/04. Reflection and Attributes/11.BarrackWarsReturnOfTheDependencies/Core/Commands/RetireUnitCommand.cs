using System;
using System.Collections.Generic;
using System.Text;

public class RetireUnitCommand : Command
{
    [Inject]
    private IRepository repository;
  
    public RetireUnitCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        var unitType = this.Data[1];
        this.repository.RemoveUnit(unitType);
        string output = unitType + " retired!";
        return output;
    }
}

