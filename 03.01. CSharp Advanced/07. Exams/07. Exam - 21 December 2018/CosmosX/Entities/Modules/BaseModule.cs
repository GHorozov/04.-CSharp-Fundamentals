using CosmosX.Entities.Modules.Contracts;
using System.Text;

namespace CosmosX.Entities.Modules
{
    public abstract class BaseModule : IModule
    {
        protected BaseModule(int id)
        {
            this.Id = id;
        }

        public int Id { get;}

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} Module - {this.Id}");

            return sb.ToString().TrimEnd();
        }
    }
}