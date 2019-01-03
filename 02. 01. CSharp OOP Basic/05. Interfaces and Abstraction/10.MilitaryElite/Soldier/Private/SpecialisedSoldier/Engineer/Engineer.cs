using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private string corps;

    public Engineer(int id, string firstName, string lastName, double salary, string corps, List<Repair> repairs)
        :base(id, firstName,lastName,salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<Repair> Repairs { get; set;}

    public override string Corps
    {
        get
        {
            return corps;
        }

        set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException("Invalid Corps");
            }
            corps = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {Corps}");
        sb.AppendLine("Repairs:");
        foreach (var repair in this.Repairs) 
        {
            sb.AppendLine(repair.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}

