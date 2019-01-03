public class Hen : Bird
{
    private const double IncreaseWeightSizePerUnit = 0.35;

    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override void FeedAnimal(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.Weight += (food.Quantity * IncreaseWeightSizePerUnit);
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }
}