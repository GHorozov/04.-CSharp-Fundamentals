namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var allInstrumentTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(IInstrument).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var instrumentType = allInstrumentTypes
                .FirstOrDefault(x => x.Name == type);
            if(instrumentType == null)
            {
                throw new InvalidOperationException("Invalid instrument type!");
            }

            var instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
		}
	}
}