namespace AnimalCentre
{
    using global::AnimalCentre.Factories;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Hotel;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private AnimalFactory animalFactory;
        private IHotel hotel;
        private List<Procedure> procedures;
        private ProcedureFactory procedureFactory;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();
            this.hotel = new Hotel();
            this.procedures = new List<Procedure>();
            this.procedureFactory = new ProcedureFactory();
            this.AdoptedAnimals = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> AdoptedAnimals { get; private set; }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("Chip");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("Vaccinate");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("Fitness");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("Play");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("DentalCare");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.GetAnimal(name);
            var procedure = this.procedureFactory.CreateProcedure("NailTrim");
            this.procedures.Add(procedure);
            procedure.DoService(currentAnimal, procedureTime);

            return $"{currentAnimal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var currentAnimal = this.hotel.GetAnimal(animalName);
            this.hotel.Adopt(animalName, owner);

            if (!this.AdoptedAnimals.ContainsKey(owner))
            {
                this.AdoptedAnimals[owner] = new List<string>();
            }

            this.AdoptedAnimals[owner].Add(animalName);


            if (currentAnimal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            var procedureList = this.procedures.Where(x => x.GetType().Name == type).ToArray();

            var sb = new StringBuilder();
            sb.AppendLine(type);
            foreach (var item in procedureList)
            {
                sb.AppendLine(item.History());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
