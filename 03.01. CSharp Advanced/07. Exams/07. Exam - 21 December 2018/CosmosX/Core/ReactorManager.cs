using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Modules.ModuleFactory;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;
        private IReactorFactory reactorFactory;
        private ModuleFactory moduleFactory;

        public ReactorManager()
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();
            this.reactorFactory = new ReactorFactory();
            this.moduleFactory = new ModuleFactory();
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);
            var reactor = this.reactorFactory.CreateReactor(reactorType, this.currentId++, container, additionalParameter);
            
            if(reactor != null)
            {
                this.reactors.Add(reactor.Id, reactor);
                this.identifiableObjects.Add(reactor.Id, reactor);
            }

            string result = string.Format(Constants.ReactorCreateMessage, reactor.Id, reactorType);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            switch (moduleType)
            {
                case "CryogenRod":
                    IEnergyModule cryogenRod = new CryogenRod(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddEnergyModule(cryogenRod);
                    this.identifiableObjects.Add(cryogenRod.Id, cryogenRod);
                    this.modules.Add(cryogenRod.Id, cryogenRod);
                    break;
                case "HeatProcessor":
                    IAbsorbingModule heatProccessor = new HeatProcessor(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(heatProccessor);
                    this.identifiableObjects.Add(heatProccessor.Id, heatProccessor);
                    this.modules.Add(heatProccessor.Id, heatProccessor);
                    break;
                case "CooldownSystem":
                    IAbsorbingModule cooldownSystem = new CooldownSystem(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(cooldownSystem);
                    this.identifiableObjects.Add(cooldownSystem.Id, cooldownSystem);
                    this.modules.Add(cooldownSystem.Id, cooldownSystem);
                    break;
            }

            string result = string.Format(Constants.ModuleCreateMessage, moduleType, this.currentId++, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            if (this.reactors.ContainsKey(id))
            {
                return this.reactors[id].ToString();
            }

            if (this.modules.ContainsKey(id))
            {
                return this.modules[id].ToString();
            }

            return "somethisng"; 
        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Where(x => x.GetType().Name == "CryoReactor")
                .Count();

            long heatReactorCount = this.reactors
                .Values
                .Where(x => x.GetType().Name == "HeatReactor")
                .Count();

            long energyModulesCount = this.identifiableObjects
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.identifiableObjects
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);


            //long cryoReactorCount = this.identifiableObjects.Values.Where(x => x.GetType().Name == "CryoReactor").Count();
            //long heatReactorCount = this.identifiableObjects.Values.Where(x => x.GetType().Name == "HeatReactor").Count();

            var sb = new StringBuilder();

            sb.AppendLine($"Cryo Reactors: {cryoReactorCount}");
            sb.AppendLine($"Heat Reactors: {heatReactorCount}");
            sb.AppendLine($"Energy Modules: {energyModulesCount}");
            sb.AppendLine($"Absorbing Modules: {absorbingModulesCount}");
            sb.AppendLine($"Total Energy Output: {totalEnergyOutput}");
            sb.AppendLine($"Total Heat Absorbing: {totalHeatAbsorbing}");

            return sb.ToString().TrimEnd();
        }
    }
}