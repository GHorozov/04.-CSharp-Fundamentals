using System;
using System.Collections.Generic;
using System.Text;

public class CreateCommand : Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWeaponFactory weaponFactory;
    [Inject]
    private IGemFactory gemFactory;

    public CreateCommand(string[] data)
       : base(data)
    {
    }

    public override void Execute()
    {
        var commandName = this.Data[0];
        var weapon = this.weaponFactory.CreateWeapon(this.Data);
        this.repository.Create(weapon);
    }
}

