using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private double rating;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public double Rating
    {
        get
        {
            this.rating = players.Select(x => x.Stats).Sum();
            return (int)Math.Round(rating);
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value.Length == 0 || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if(!players.Any(x => x.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        else
        {
            var currentPlayer = players.FirstOrDefault(x => x.Name == playerName);
            players.Remove(currentPlayer);
        }
    }
}
