namespace AnimalCentre.Models.Procedures
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;

    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ReduceEnergy(6);
                animal.AddHappiness(12);
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
