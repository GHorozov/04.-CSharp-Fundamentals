using System;

public class Topping
{
    private const double BaseCaloriesPerGram = 2;
    private const double MeatModifier = 1.2;
    private const double VeggiesModifier = 0.8;
    private const double CheeseModifier = 1.1;
    private const double SauceModifier = 0.9;

    private string name;
    private double weight;
    private double caloriesPerGram;

    public Topping(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public double CaloriesPerGram
    {
        get
        {
            caloriesPerGram = CalculateCalories();
            return caloriesPerGram;
        }
    }

    private string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.name = value;
        }
    }

    private double Weight
    {
        get
        {
            return weight;
        }

        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Name} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }

    private double CalculateCalories()
    {
        var toppingTypeModifier = 0.0;

        switch (name.ToLower())
        {
            case "meat":
                toppingTypeModifier = MeatModifier;
                break;
            case "veggies":
                toppingTypeModifier = VeggiesModifier; 
                break;
            case "cheese":
                toppingTypeModifier = CheeseModifier;
                break;
            case "sauce":
                toppingTypeModifier = SauceModifier;
                break;
            default:
                throw new ArgumentException("Topping type modifier is not set.");
        }

        var calories = (weight * BaseCaloriesPerGram) * toppingTypeModifier;

        return calories;
    }
}

