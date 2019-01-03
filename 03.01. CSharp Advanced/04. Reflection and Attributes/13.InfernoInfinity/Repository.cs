using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Repository : IRepository
{
    private IList<IWeapon> weapons;
    private IWriter writer;

    public Repository(IWriter writer)
    {
        this.weapons = new List<IWeapon>();
        this.writer = writer;
    }

    public string Statistics
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var weapon in this.weapons)
            {
                if(weapon != null)
                {
                    sb.AppendLine(weapon.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }

    public void Create(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public void Add(string weaponName, int socketIndex,IGem gem)
    {
        var weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);
        if(weapon == null)
        {
            throw new ArgumentException($"{weaponName} is missing from repository.");
        }

        if(socketIndex >= 0 && socketIndex <= weapon.Sockets.Length - 1)
        {
            weapon.Sockets[socketIndex] = gem;
        }
    }

    public void Remove(string weaponName, int socketIndex)
    {
        var weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);
        if (weapon == null)
        {
            throw new ArgumentException($"{weaponName} is missing from repository.");
        }

        if (socketIndex >= 0 && socketIndex <= weapon.Sockets.Length - 1)
        {
            weapon.Sockets[socketIndex] = null;
        }
    }

    public void Print(string weaponName)
    {
        var weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);
        if (weapon == null)
        {
            throw new ArgumentException($"{weaponName} is missing from repository.");
        }

        this.writer.WriteLine(weapon.ToString());
    }
}

