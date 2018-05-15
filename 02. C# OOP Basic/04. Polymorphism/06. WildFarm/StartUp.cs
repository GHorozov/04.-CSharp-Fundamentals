using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var animalFoodInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var animalFoodType = animalFoodInfo[0];
            var animalFoodQuantity = int.Parse(animalFoodInfo[1]);

            Food food = null;
            switch (animalFoodType)
            {
                case "Vegetable":
                    food = new Vegetable(animalFoodQuantity);
                    break;
                case "Meat":
                    food = new Meat(animalFoodQuantity);
                    break;
                default:
                    break;
            }

            var animalInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);
            var animalLivingRegion = animalInfo[3];

            switch (animalType)
            {
                case "Cat":
                    var animalBreed = animalInfo[4];
                    Animal cat = new Cat(animalType, animalName, animalWeight, animalLivingRegion, animalBreed);
                    cat.MakeSound();
                    cat.Eat(food);
                    Console.WriteLine(cat.ToString());
                    break;
                case "Tiger":
                    Animal tiger = new Tiger(animalType, animalName, animalWeight, animalLivingRegion);
                    tiger.MakeSound();
                    tiger.Eat(food);
                    Console.WriteLine(tiger.ToString());
                    break;
                case "Mouse":
                    Animal mouse = new Mouse(animalType, animalName, animalWeight, animalLivingRegion);
                    mouse.MakeSound();
                    mouse.Eat(food);
                    Console.WriteLine(mouse.ToString());
                    break;
                case "Zebra":
                    Animal zebra = new Zebra(animalType, animalName, animalWeight, animalLivingRegion);
                    zebra.MakeSound();
                    zebra.Eat(food);
                    Console.WriteLine(zebra.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}

