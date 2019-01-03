namespace AnimalCentre.Models.Animals
{
    using global::AnimalCentre.Models.Contracts;
    using System;

    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; protected set; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; protected set; }

        public string Owner { get; protected set; }

        public bool IsAdopt { get; protected set; }

        public bool IsChipped  { get;protected set; }

        public bool IsVaccinated { get;protected set; }

        //methods
        public void DecreaseProcedureTime(int points)
        {
            this.ProcedureTime -= points;
        }

        public void ReduceHappiness(int points)
        {
            this.Happiness -= points;
        }

        public void ReduceEnergy(int points)
        {
            this.Energy -= points;
        }

        public void ChipAnimal()
        {
            this.IsChipped = true;
        }

        public void VaccinateAnimal()
        {
            this.IsVaccinated = true;
        }

        public void AddEnergy(int points)
        {
            this.Energy += points;
        }
        public void AddHappiness(int points)
        {
            this.Happiness += points;
        }

        public void ChangeOwner(string newOwner)
        {
            this.Owner = newOwner;
        }

        public void ChangeAdoptStatus()
        {
            this.IsAdopt = true;
        }

        public override string ToString()
        {
            return $"Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
