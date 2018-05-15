using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.dough = dough;
        this.toppings = new List<Topping>();
    }



    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == null || value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set
        {
            this.toppings = value;
        }
    }


    public void AddToppings(Topping topping)
    {
        this.toppings.Add(topping);
    }

    public double GetTotalcalories()
    {
        var calories = 0.0;
        calories += this.dough.GetCalories();
        this.Toppings.ForEach(t => calories += t.GetCalories());

        return calories;
    }
}

