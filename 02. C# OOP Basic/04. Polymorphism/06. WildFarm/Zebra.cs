using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Zebra : Mammal
{
    public Zebra(string type, string name, double weight, string livingRegion):base(type,name,weight,livingRegion)
    {

    }
    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override string ToString()
    {
        return $"{base.Type}[{base.Name}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}

