public class Siamese : Cat
{
    public Siamese(string species, string name, long earSize)
        :base(species, name)
    {
        this.EarSize = earSize;
    }

    public long EarSize { get; set; }

    public override string ToString()
    {
        return $"{base.Species} {base.Name} {this.EarSize}";
    }
}