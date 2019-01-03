using System;
using System.Collections.Generic;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    protected Animal(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
    }

    public Animal(string name, double weight, int foodEaten)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract string ProduceSound();

    public abstract void FeedAnimal(Food food);

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}";
    }
}
