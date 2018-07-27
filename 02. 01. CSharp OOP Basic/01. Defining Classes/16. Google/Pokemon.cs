public class Pokemon
{
    public string pokemonName;
    public string pokemonType;

    public Pokemon(string pokemonName, string pokemonType)
    {
        this.pokemonName = pokemonName;
        this.pokemonType = pokemonType;
    }

    public override string ToString()
    {
        return $"{pokemonName} {pokemonType}";
    }
}