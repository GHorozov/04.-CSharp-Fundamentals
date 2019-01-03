namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var allInstumentTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(IInstrument).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var instrumentType = allInstumentTypes.FirstOrDefault(x => x.Name == type);
            if(instrumentType == null)
            {
                throw new InvalidOperationException("Invalid instrument type!");
            }

            var instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
        }
    }
}