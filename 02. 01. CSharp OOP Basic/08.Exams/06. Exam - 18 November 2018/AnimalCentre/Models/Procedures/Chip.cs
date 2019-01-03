namespace AnimalCentre.Models.Procedures
{
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ReduceHappiness(5);
                if (!animal.IsChipped)
                {
                    animal.ChipAnimal();
                }
                else
                {
                    throw new ArgumentException($"{animal.Name} is already chipped");
                }

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
