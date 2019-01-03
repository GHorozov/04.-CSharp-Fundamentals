using System;
using System.Collections.Generic;
using System.Text;

public class RemoveCommand : Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWeaponFactory weaponFactory;
    [Inject]
    private IGemFactory gemFactory;

    public RemoveCommand(string[] data)
        : base(data)
    {
    }

    public override void Execute()
    {
        var weaponName = this.Data[1];
        var socketIndex = int.Parse(this.Data[2]);
        this.repository.Remove(weaponName, socketIndex);
    }
}

