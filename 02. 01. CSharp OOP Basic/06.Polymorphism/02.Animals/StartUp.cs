namespace _02.Animals
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            var listOFAnimals = new List<Animal>();
            listOFAnimals.Add(cat);
            listOFAnimals.Add(dog);

            foreach (var animal in listOFAnimals)
            {
                Console.WriteLine(animal.ExplainSelf());
            }
        }
    }
}
