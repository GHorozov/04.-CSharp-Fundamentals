using System;

public class Cat : Feline
{
    private const double IncreaseWeightSizePerUnit = 0.30;

    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void FeedAnimal(Food food)
    {
        var foodType = food.GetType().Name;
        if (foodType != "Vegetable" && foodType != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += (food.Quantity * IncreaseWeightSizePerUnit);
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}