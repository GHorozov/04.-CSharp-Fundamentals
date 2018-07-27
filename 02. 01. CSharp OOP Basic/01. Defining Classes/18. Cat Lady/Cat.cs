public class Cat
{
    public Cat(string species, string name)
    {
        this.Species = species;
        this.Name = name;
    }

    public string  Species { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{this.Species} {this.Name}";
    }
}

