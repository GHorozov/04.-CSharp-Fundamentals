using System;

public class Dog : Mammal
{
    private const double IncreaseWeightSizePerUnit = 0.40;

    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
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
        return "Woof!";
    }
}