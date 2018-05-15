using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        Animal cat = new Cat("Pesho", "Whiskas");
        Animal dog = new Dog("Gosho", "Meat");

        var listOFAnimals = new List<Animal>();
        listOFAnimals.Add(cat);
        listOFAnimals.Add(dog);

        foreach (var animal in listOFAnimals)
        {
            Console.WriteLine(animal.ExplainMyself());
        }
    }
}
