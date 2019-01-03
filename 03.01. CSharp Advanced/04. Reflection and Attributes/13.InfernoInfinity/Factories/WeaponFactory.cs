using System;
using System.Collections.Generic;
using System.Text;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string[] data)
    {
        var weaponInput = data[1].Split(" ");
        var rarity = weaponInput[0];
        var weaponType = weaponInput[1];
        var weaponName = data[2];

        var type = Type.GetType(weaponType);
        var weapon = (IWeapon)Activator.CreateInstance(type, new object[] { weaponName, rarity });

        return weapon;
    }
}

