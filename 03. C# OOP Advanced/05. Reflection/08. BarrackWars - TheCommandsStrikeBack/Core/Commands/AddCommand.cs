using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AddCommand : Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IUnitFactory unitFactory;

    public AddCommand(string[] data) : base(data)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}

