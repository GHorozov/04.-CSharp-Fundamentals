using System;

public class Owl : Bird
{
    private const double IncreaseWeightSizePerUnit = 0.25;

    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
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
        return "Hoot Hoot";
    }
}