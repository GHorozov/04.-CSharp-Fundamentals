using System;

public class Tiger : Feline
{
    private const double IncreaseWeightSizePerUnit = 1.00;

    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void FeedAnimal(Food food)
    {
        var foodType = food.GetType().Name;
        if (foodType != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += (food.Quantity * IncreaseWeightSizePerUnit);
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }
}