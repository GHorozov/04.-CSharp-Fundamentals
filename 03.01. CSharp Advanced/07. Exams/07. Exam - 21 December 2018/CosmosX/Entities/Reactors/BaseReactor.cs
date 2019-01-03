using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using System.Text;

namespace CosmosX.Entities.Reactors
{
    public abstract class BaseReactor : IReactor
    {
        private readonly IContainer moduleContainer;
        private int id;

        private long totalEnergyOutput;

        protected BaseReactor(int id, IContainer moduleContainer)
        {
            this.Id = id;
            this.moduleContainer = moduleContainer;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public virtual long TotalEnergyOutput
        {
            get
            {
                this.totalEnergyOutput = this.moduleContainer.TotalEnergyOutput;

                return this.totalEnergyOutput;
            }
            protected set
            {
                this.totalEnergyOutput = value;
            }
        }


        public virtual long TotalHeatAbsorbing  => this.moduleContainer.TotalHeatAbsorbing;

        public int ModuleCount => this.moduleContainer.ModulesByInput.Count;

        public void AddEnergyModule(IEnergyModule energyModule)
        {
            this.moduleContainer.AddEnergyModule(energyModule);
        }

        public void AddAbsorbingModule(IAbsorbingModule absorbingModule)
        {
            this.moduleContainer.AddAbsorbingModule(absorbingModule); 
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - {this.Id}");
            sb.AppendLine($"Energy Output: {this.TotalEnergyOutput}");
            sb.AppendLine($"Heat Absorbing: {this.TotalHeatAbsorbing}");
            sb.AppendLine($"Modules: {this.ModuleCount}");

            return sb.ToString().TrimEnd();
        }
    }
}