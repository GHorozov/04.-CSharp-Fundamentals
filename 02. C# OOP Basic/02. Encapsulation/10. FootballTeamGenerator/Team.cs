using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Team
{
    public Team(string name)
    {
        this.name = name;
        this.players = new List<Player>();
    }

    private string name;
    private List<Player> players;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should be empty.");
            }
            this.name = name;
        }
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string namePlayer)
    {
        var name = this.players.FirstOrDefault(p => p.Name == namePlayer);

        if (name == null)
        {
            throw new ArgumentException($"Player {namePlayer} is not in {this.Name} team.");
        }

        this.players.Remove(name);
    }

    public int CalculatingRaiting()
    {
        if (this.players.Count > 0)
        {
            return (int)Math.Round(this.players.Select(p => p.CalculatingAverageSkillPlayer()).Sum() / (double)this.players.Count);
        }
        return 0;
    }

}
