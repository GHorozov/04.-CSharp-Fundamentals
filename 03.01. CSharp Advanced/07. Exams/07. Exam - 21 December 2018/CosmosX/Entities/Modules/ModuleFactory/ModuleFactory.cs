using CosmosX.Entities.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CosmosX.Entities.Modules.ModuleFactory
{
    public class ModuleFactory
    {
        public IModule CreateModule(string moduleTypeName, int id, int aditionalParameter)
        {
            var allModuleTypes = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsAbstract)
                 .ToArray();

            var currentModuleType = allModuleTypes.FirstOrDefault(x => x.Name == moduleTypeName);

            var module = (IModule)Activator.CreateInstance(currentModuleType, new object[] { id, aditionalParameter});

            return module;
        }
    }
}
