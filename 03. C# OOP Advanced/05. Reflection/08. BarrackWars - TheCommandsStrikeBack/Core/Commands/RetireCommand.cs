using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03BarracksFactory.Contracts;

public class RetireCommand : Command
{
    [Inject]
    private IRepository repository;

    public RetireCommand(string[] data) : base(data)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        this.repository.RemoveUnit(unitType);
        return $"{unitType} retired!";
    }
}
