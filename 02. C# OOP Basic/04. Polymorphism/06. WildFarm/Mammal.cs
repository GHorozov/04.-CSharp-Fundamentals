using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string type, string name, double weight, string livingRegion) : base(type,name,weight)
    {
        this.LivingRegion = livingRegion;
    }
    public string LivingRegion
    {
        get
        {
            return this.livingRegion;
        }
        set
        {
            this.livingRegion = value;
        }
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable")
        {
            Console.WriteLine($"{base.Type}s are not eating that type of food!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
        }
    }

    public override string ToString()
    {
        return $"{base.Type} {base.Name} {base.Weight} {base.FoodEaten}";
    }

}

