using System;

public class Dough
{
   private const double BaseCaloriesPerGram = 2;
   private const double WhiteModifier = 1.5;
   private const double WholegrainModifier = 1.0;
   private const double CrispyModifier = 0.9;
   private const double ChewyModifier = 1.1;
   private const double HomemadeModifier = 1.0;

    private string flour;
    private string technique;
    private double weight;
    private double caloriesPerGram;

    public Dough(string flour, string technique, double weight)
    {
        this.Flour = flour;
        this.Technique = technique;
        this.Weight = weight;
    }

    public double CaloriesPerGram
    {
        get
        { 
            this.caloriesPerGram = CalculateCalories();
            return caloriesPerGram;
        }
    }

    private string Technique 
    {
        get
        {
            return technique;
        }

        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            technique = value;
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
            if(value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    private string Flour
    {
        get
        {
            return flour;
        }

        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flour = value;
        }
    }

    private double CalculateCalories()
    {
        var flourTypeModifier = 0.0;
        var bakingTehniqueModifier = 0.0;

        switch (flour.ToLower())
        {
            case "white":
                flourTypeModifier = WhiteModifier;
                break;
            case "wholegrain":
                flourTypeModifier = WholegrainModifier;
                break;
            default:
                throw new ArgumentException("Flour type modifier is not set.");
        }

        switch (technique.ToLower())
        {
            case "crispy":
                bakingTehniqueModifier = CrispyModifier;
                break;
            case "chewy":
                bakingTehniqueModifier = ChewyModifier;
                break;
            case "homemade":
                bakingTehniqueModifier = HomemadeModifier;
                break;
            default:
                throw new ArgumentException("Baking tehnique modifier is not set.");
        }

        var calories = (this.weight * BaseCaloriesPerGram) * flourTypeModifier * bakingTehniqueModifier;

        return calories;
    }
}

