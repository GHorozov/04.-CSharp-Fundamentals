using System;

public class Mouse : Mammal
{
    private const double IncreaseWeightSizePerUnit = 0.10;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override void FeedAnimal(Food food)
    {
        var foodType = food.GetType().Name;
        if (foodType != "Vegetable" && foodType != "Fruit")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += (food.Quantity * IncreaseWeightSizePerUnit);
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }
}