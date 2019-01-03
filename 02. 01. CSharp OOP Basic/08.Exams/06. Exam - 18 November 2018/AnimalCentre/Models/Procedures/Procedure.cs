namespace AnimalCentre.Models.Procedures
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        private List<Animal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<Animal>();
        }

        public IReadOnlyCollection<Animal> ProcedureHistory => this.procedureHistory;

        public abstract void DoService(IAnimal animal, int procedureTime);

        public void AddToHistory(Animal animal)
        {
            this.procedureHistory.Add(animal);
        }

        public string History()
        {
            var sb = new StringBuilder();
            foreach (var animal in this.procedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
