using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Animal
{
    private string type;
    private string name;  
    private double weight;
    private int foodEaten;

    public Animal(string type, string name, double weight)
    {
        this.Type = type;
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

    public int FoodEaten
    {
        get
        {
            return this.foodEaten;
        }
        set
        {
            this.foodEaten = value;
        }
    }

    public abstract void MakeSound();


    public abstract void Eat(Food food);

    public override string ToString()
    {
        return $"{this.Type}[{this.Name} {this.weight}]";
    }
}

