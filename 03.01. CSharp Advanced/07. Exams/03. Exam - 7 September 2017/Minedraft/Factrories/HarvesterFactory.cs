using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        var allHarvesterTypes = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(x => typeof(IHarvester).IsAssignableFrom(x) && !x.IsAbstract)
            .ToArray();

        var harvesterType = allHarvesterTypes.FirstOrDefault(x => x.Name == type + "Harvester");
        if(harvesterType == null)
        {
            throw new InvalidOperationException("Invalid harvester type!");
        }

        var harvester = (IHarvester)Activator.CreateInstance(harvesterType, new object[] { id, oreOutput, energyReq });

        return harvester;
    }

    //public static Harvester GenerateHarvester(IList<string> args)
    //{
    //    string type = args[0];

    //    var id = int.Parse(args[1]);
    //    var oreOutput = double.Parse(args[2]);
    //    var energyReq = double.Parse(args[3]);

    //    Type clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Harvester");
    //    var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
    //    Harvester harvester = (Harvester)ctors[0].Invoke(new object[] { id, oreOutput, energyReq });
    //    return harvester;
    //}

}