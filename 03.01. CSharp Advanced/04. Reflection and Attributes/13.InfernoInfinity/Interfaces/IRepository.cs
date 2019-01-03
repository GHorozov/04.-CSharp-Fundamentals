using System;
using System.Collections.Generic;
using System.Text;

public interface IRepository
{
    void Create(IWeapon weapon);
    void Add(string weaponName, int socketIndex, IGem gem);
    void Remove(string weaponName, int socketIndex);
    void Print(string weaponName);
    string Statistics { get; }
}

