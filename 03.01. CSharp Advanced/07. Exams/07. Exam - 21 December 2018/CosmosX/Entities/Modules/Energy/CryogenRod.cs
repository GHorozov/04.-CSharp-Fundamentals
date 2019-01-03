using CosmosX.Entities.Modules.Energy.Contracts;
using System.Text;

namespace CosmosX.Entities.Modules.Energy
{
    public class CryogenRod : BaseModule, IEnergyModule
    {
        public CryogenRod(int id, int energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public int EnergyOutput { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Energy Output: {this.EnergyOutput}");

            return base.ToString() + sb.ToString().TrimEnd();
        }
    }
}