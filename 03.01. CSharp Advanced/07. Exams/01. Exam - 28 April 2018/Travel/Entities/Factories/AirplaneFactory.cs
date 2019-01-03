namespace Travel.Entities.Factories
{
    using Contracts;
    using Airplanes.Contracts;
    using System;
    using Travel.Entities.Airplanes;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            var allAirplaneTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(IAirplane).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var airplaneType = allAirplaneTypes.FirstOrDefault(x => x.Name == type);
            if (airplaneType == null)
            {
                throw new InvalidOperationException($"Invalid airplane type!");
            }

            var airplane = (IAirplane)Activator.CreateInstance(airplaneType);
            return airplane;
        }
    }
}