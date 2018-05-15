using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Cat : Felime
{
    private string breed;

    public Cat(string type, string name, double weight, string livingRegion, string breed) : base(type,name,weight,livingRegion)
    {
        this.breed = breed;
    }
    

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        base.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{base.Type}[{base.Name}, {this.breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}

