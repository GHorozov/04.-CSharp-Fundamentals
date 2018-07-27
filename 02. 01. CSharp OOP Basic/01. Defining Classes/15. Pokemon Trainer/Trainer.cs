using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string name;
    public int badges = 0;
    public List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        pokemons = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public bool CheckForPokemon(string element)
    {
        return pokemons.Any(x => x.element == element);
    }

    public void AddBadge()
    {
        this.badges += 1;
    }

    public void DecreaseHealth()
    {
        pokemons.ForEach(x => x.DecreaseHealth());
        this.pokemons = pokemons.Where(x => x.health > 0).ToList();
    }

    public override string ToString()
    {
        return $"{this.name} {this.badges} {this.pokemons.Count}";
    }
}