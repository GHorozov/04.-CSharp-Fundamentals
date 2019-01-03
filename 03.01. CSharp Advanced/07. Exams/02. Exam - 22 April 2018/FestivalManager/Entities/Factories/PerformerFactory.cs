namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
            var type = typeof(Performer);
            var performer = (IPerformer)Activator.CreateInstance(type, new object[] { name, age });

			return performer;
		}
	}
}