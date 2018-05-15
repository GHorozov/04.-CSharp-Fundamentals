using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tiger : Felime
{
    public Tiger(string type, string name, double weight, string livingRegion):base(type,name,weight,livingRegion)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine($"ROAAR!!!");
    }

    public override void Eat(Food food)
    {
        if(food.GetType().Name != "Meat")
        {
            Console.WriteLine($"{base.Type}s are not eating that type of food!");
        }
        else
        {
            base.FoodEaten += food.Quantity;
        }
    }

    public override string ToString()
    {
        return $"{base.Type}[{base.Name}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}

