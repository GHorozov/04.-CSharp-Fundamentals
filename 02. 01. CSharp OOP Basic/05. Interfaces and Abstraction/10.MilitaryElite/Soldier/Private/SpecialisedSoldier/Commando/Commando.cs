using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private string corps;

    public Commando(int id, string firstName, string lastName, double salary, string corps, List<Mission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<Mission> Missions { get; set; }

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
        sb.AppendLine("Missions:");
        foreach (var mission in this.Missions)
        {
            sb.AppendLine(mission.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}

