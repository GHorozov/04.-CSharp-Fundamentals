namespace _06.WildFarm
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            AnimalFactory animalFactory = new AnimalFactory();
            Foodfactory foodfactory = new Foodfactory();
            var animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    var inputArgs = input.Split();
                    var currentAnimal = animalFactory.GetAnimal(inputArgs);
                    animals.Add(currentAnimal);
                    Console.WriteLine(currentAnimal.ProduceSound());
                    var food = foodfactory.GetFood();
                    currentAnimal.FeedAnimal(food);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
