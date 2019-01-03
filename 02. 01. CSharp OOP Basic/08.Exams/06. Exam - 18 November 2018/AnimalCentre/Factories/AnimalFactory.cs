namespace AnimalCentre.Factories
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string animalType, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;
            switch (animalType)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new InvalidOperationException("Invalid animal type!");
            }

            return animal;
        }
    }
}
