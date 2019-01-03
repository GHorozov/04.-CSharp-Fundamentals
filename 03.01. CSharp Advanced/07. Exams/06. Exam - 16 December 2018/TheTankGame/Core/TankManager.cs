namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TheTankGame.Core.Contracts;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories;
    using TheTankGame.Entities.Parts.Factories.Contracts;
    using TheTankGame.Entities.Vehicles.Contracts;
    using TheTankGame.Entities.Vehicles.Factories;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;
    using TheTankGame.Utils;

    public class TankManager : IManager
    {
        private IDictionary<string, IVehicle> vehicles;
        private IDictionary<string, IPart> parts;
        private IList<string> defeatedVehicles;
        private IBattleOperator battleOperator;
        private IVehicleFactory vehicleFactory;
        private IPartFactory partFactory;

        public TankManager(IBattleOperator battleOperator)
        {
            this.battleOperator = battleOperator;
            this.vehicles = new Dictionary<string, IVehicle>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedVehicles = new List<string>();
            this.battleOperator = battleOperator;
            this.vehicleFactory = new VehicleFactory();
            this.partFactory = new PartFactory();
        }

        public string AddVehicle(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            var vehicle = this.vehicleFactory.CreateVehicle(vehicleType, model, weight, price, attack, defense, hitPoints);

            if(vehicle != null)
            {
               vehicles.Add(vehicle.Model, vehicle);
            }

            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string vehicleModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            var part = this.partFactory.CreatePart(partType, model, weight, price, additionalParameter);
            
            if (part != null)
            {
                this.parts.Add(part.Model, part);
                string methodName = "Add" + partType + "Part";
                this.vehicles[vehicleModel]
                    .GetType()
                    .GetMethod(methodName)
                    .Invoke(this.vehicles[vehicleModel], new object[] { part });
            }

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                vehicleModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];

            if (this.vehicles.ContainsKey(model))
            {
                return this.vehicles[model].ToString();
            }

            if (this.parts.ContainsKey(model))
            {
                return this.parts[model].ToString();
            }

            return "Bullshit";
        }

        public string Battle(IList<string> arguments)
        {
            string attackerVehicleModel = arguments[0];
            string targetVehicleModel = arguments[1];

            string winnerVehicleModel = this.battleOperator.Battle(this.vehicles[attackerVehicleModel], this.vehicles[targetVehicleModel]);

            if (winnerVehicleModel.Equals(attackerVehicleModel))
            {
                this.vehicles[targetVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(targetVehicleModel);
                this.defeatedVehicles.Add(targetVehicleModel);
            }
            else
            {
                this.vehicles[attackerVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(attackerVehicleModel);
                this.defeatedVehicles.Add(attackerVehicleModel);
            }

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerVehicleModel,
                targetVehicleModel,
                winnerVehicleModel);
        }

        public string Terminate(IList<string> arguments)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Remaining Vehicles: ");

            if (this.vehicles.Count > 0)
            {
                sb.AppendLine(string.Join(", ", this.vehicles.Values
                            .Select(v => v.Model)
                            .ToArray()));
            }
            else
            {
                sb.AppendLine("None");
            }

            sb.Append("Defeated Vehicles: ");

            if (this.defeatedVehicles.Count > 0)
            {
                sb.AppendLine(string.Join(", ", this.defeatedVehicles));
            }
            else
            {
                sb.AppendLine("None");
            }

            sb.Append("Currently Used Parts: ")
                .Append(this.parts.Count);

            return sb.ToString();
        }
    }
}