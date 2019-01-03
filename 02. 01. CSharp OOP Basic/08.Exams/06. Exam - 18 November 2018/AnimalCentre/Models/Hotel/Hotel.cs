namespace AnimalCentre.Models.Hotel
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Hotel : IHotel
    {
        private const int CONST_CAPACITY = 10;

        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = CONST_CAPACITY;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if(this.Animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var targetAnimal = this.Animals[animalName];

            targetAnimal.ChangeOwner(owner);
            targetAnimal.ChangeAdoptStatus();
            this.animals.Remove(animalName);
        }

        public IAnimal GetAnimal(string animalName)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            return this.Animals[animalName];
        }
    }
}
