namespace AnimalCentre.Models.Contracts
{
    using global::AnimalCentre.Models.Animals;
    using System.Collections.Generic;

    public interface IProcedure
    {
        IReadOnlyCollection<Animal> ProcedureHistory { get; }

        string History();

        void DoService(IAnimal animal, int procedureTime);

        void AddToHistory(Animal animal);
    }
}
