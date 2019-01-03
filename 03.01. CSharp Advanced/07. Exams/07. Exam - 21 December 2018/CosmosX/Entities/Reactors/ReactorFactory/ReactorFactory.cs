using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        private const string PostFixReactor = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            var allReactorTypes = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .Where(x => typeof(IReactor).IsAssignableFrom(x) && !x.IsAbstract)
                 .ToArray();

            var currentReactorType = allReactorTypes.FirstOrDefault(x => x.Name == reactorTypeName + PostFixReactor);
            //if(currentReactorType == null)
            //{
            //    throw new InvalidOperationException("Invalid reactor type!");
            //}

            var reactor = (IReactor)Activator.CreateInstance(currentReactorType, new object[] { id, moduleContainer, additionalParameter});

            return reactor;
        }
    }
}
