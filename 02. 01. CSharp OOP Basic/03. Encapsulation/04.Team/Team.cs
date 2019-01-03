using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    public void AddPlayer(Person person)
    {
        if(person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First team has {this.FirstTeam.Count} players");
        sb.AppendLine($"Reserve team has {this.ReserveTeam.Count} players");

        return sb.ToString().TrimEnd(); 
    }
}

