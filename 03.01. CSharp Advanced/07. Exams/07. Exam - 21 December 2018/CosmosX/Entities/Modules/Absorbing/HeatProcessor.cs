using CosmosX.Entities.Modules.Absorbing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosX.Entities.Modules.Absorbing
{
    public class HeatProcessor : BaseModule, IAbsorbingModule
    {
        public HeatProcessor(int id, int heatAbsorbing) 
            : base(id)
        {
            this.HeatAbsorbing = heatAbsorbing;
        }

        public int HeatAbsorbing { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Heat Absorbing: {this.HeatAbsorbing}");

            return base.ToString() + sb.ToString().TrimEnd();
        }
    }
}
