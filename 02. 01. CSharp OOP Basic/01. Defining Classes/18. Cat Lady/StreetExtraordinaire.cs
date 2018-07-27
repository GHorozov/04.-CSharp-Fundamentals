internal class StreetExtraordinaire : Cat
{
    public StreetExtraordinaire(string species, string name, double decibelsOfMeows)
        :base(species, name)
    {
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public double DecibelsOfMeows { get; set; }

    public override string ToString()
    {
        return $"{base.Species} {base.Name} {this.DecibelsOfMeows}";
    }
}