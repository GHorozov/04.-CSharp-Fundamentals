using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        int idToInspect;
        if(!int.TryParse(this.Arguments[0], out idToInspect))
        {
            return string.Format(Constants.NoEntityWithID, this.Arguments[0]);
        }

        var allEntities = new List<IEntity>();

        var harvesterList = this.HarvesterController
            .GetType()
            .GetProperties()
            .FirstOrDefault(x => x.Name == "Entities");

        var harvesters = (IReadOnlyCollection<IEntity>)harvesterList.GetValue(this.HarvesterController);
        allEntities.AddRange(harvesters);

        var providerList = this.ProviderController
            .GetType()
            .GetProperties()
            .FirstOrDefault(x => x.Name == "Entities");

        var providers = (IReadOnlyCollection<IEntity>)providerList.GetValue(this.ProviderController);
        allEntities.AddRange(providers);

        if(allEntities.Any(x => x.ID == idToInspect))
        {
            var entity = allEntities.FirstOrDefault(x => x.ID == idToInspect);

            var entityType = entity.GetType().FullName;
            var entityDurability = entity.Durability;

            return string.Format(Constants.EntityWithID, entityType, entityDurability);
        }
        else
        {
            return string.Format(Constants.NoEntityWithID, idToInspect);
        }
    }
}

