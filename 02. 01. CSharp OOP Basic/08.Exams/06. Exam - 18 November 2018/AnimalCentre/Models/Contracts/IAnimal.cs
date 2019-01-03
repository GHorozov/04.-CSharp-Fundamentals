namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        int Energy { get; }

        int Happiness { get; }

        int ProcedureTime { get; }

        string Owner { get; }

        bool IsAdopt { get; }

        bool IsChipped { get;}

        bool IsVaccinated { get;}

        void DecreaseProcedureTime(int points);

        void ReduceHappiness(int points);

        void ReduceEnergy(int points);

        void ChipAnimal();

        void VaccinateAnimal();

        void AddEnergy(int points);

        void AddHappiness(int points);

        void ChangeOwner(string newOwner);

        void ChangeAdoptStatus();

        string ToString();
    }
}
