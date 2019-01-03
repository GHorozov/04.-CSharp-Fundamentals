namespace AnimalCentre.Models.Procedures
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;

    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ReduceHappiness(3);
                animal.AddEnergy(10);
                animal.DecreaseProcedureTime(procedureTime);
                this.AddToHistory((Animal)animal);
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}
