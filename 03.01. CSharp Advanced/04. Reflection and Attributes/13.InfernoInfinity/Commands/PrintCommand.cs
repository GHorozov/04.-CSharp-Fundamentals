using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWeaponFactory weaponFactory;
    [Inject]
    private IGemFactory gemFactory;

    public PrintCommand(string[] data) 
        : base(data)
    {
    }

    public override void Execute()
    {
        var weaponName = this.Data[1];
        this.repository.Print(weaponName);
    }
}

