using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;
    private double totalCalories;

    public Pizza(string pizzaName, Dough pizzaDough)
    {
        this.Name = pizzaName;
        this.Dough = pizzaDough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get
        {
            return name;
        }

        private set
        {
            if(value == " " || value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count < 10)
        {
            this.toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");

        }
    }

    public int NumberOfToppings
    {
        get
        {
            return toppings.Count;
        }
    }

    public double TotalCalories
    {
        get
        {
            this.totalCalories = CalculateTotalcalories();
            return totalCalories;
        }
    }

    private double CalculateTotalcalories()
    {
        var doughCalories = this.dough.CaloriesPerGram;
        var toppingCalories = this.toppings.Select(x => x.CaloriesPerGram).Sum();
        var totalPizzaCalories = doughCalories + toppingCalories;

        return totalPizzaCalories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories:f2} Calories.";
    }
}

