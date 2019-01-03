public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return base.ToString() + $", {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}