namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            var allSetTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(ISet).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var setType = allSetTypes.FirstOrDefault(x => x.Name == type);
            if (setType == null)
            {
                throw new InvalidOperationException("Invalid set type!");
            }

            var set = (ISet)Activator.CreateInstance(setType, new object[] { name});

            return set;
        }
    }
}
