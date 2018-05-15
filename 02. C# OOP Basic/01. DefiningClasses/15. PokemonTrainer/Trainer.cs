using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Trainer
{
    //name, number of badges 
    private string name;
    private int numberOfBadges=0;
    private List<Pokemon> pokemon;

    public Trainer(string name)
    {
        this.name = name;
        this.pokemon = new List<Pokemon>();
    }
    public Trainer(string name, Pokemon pokemon):this(name)
    {
        this.pokemon = new List<Pokemon>();
    }

    public Trainer(string name, int numberOfBadges, Pokemon pokemon) :this(name, pokemon)
    {
        this.numberOfBadges = numberOfBadges;
    }

    public string Name
    {
        get { return this.name; }
    }
    public int NumberOfBadges
    {
        get { return this.numberOfBadges; }
    }

    public List<Pokemon> Pokemon
    {
        get { return this.pokemon; }
    }

    public void AddBadges()
    {
        this.numberOfBadges++;
    }
    internal void ClearDeadPokemons()
    {
        if(this.pokemon.Count > 0 && this.pokemon.Where(p => p.Health <= 0).FirstOrDefault() != null)
        {
            this.pokemon = new List<Pokemon>(this.pokemon.Where(p => p.Health > 0));
        }
    }
}

