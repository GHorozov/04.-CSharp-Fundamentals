using System;
using System.Reflection;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;
using System.Linq;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Miscellaneous;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            var allVehiclesTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(IVehicle).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var currentVehicleType = allVehiclesTypes.FirstOrDefault(x => x.Name == vehicleType);
            //if(currentVehicleType == null)
            //{
            //    throw new InvalidOperationException("Invalid vahicle type!");
            //}

            var vehicle = (IVehicle)Activator.CreateInstance(currentVehicleType, new object[] { model, weight, price, attack, defense, hitPoints, new VehicleAssembler()});

            return vehicle;
        }
    }
}
