using System;
using System.Collections.Generic;
using System.Text;

public class AddCommand :Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWeaponFactory weaponFactory;
    [Inject]
    private IGemFactory gemFactory;

    public AddCommand(string[] data) 
        : base(data)
    {
    }

    public override void Execute()
    {
        var weaponName = this.Data[1];
        var socketIndex = int.Parse(this.Data[2]);
        var gem = this.gemFactory.CreateGem(this.Data);
        this.repository.Add(weaponName, socketIndex, gem);
    }
}

