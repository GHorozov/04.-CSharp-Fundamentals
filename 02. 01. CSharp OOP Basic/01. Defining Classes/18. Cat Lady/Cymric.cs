internal class Cymric : Cat
{
    public Cymric(string species, string name, double furLength)
        :base(species, name)
    {
        this.FurLength = furLength;
    }

    public double FurLength { get; set; }

    public override string ToString()
    {
        return $"{base.Species} {base.Name} {this.FurLength:f2}";
    }
}