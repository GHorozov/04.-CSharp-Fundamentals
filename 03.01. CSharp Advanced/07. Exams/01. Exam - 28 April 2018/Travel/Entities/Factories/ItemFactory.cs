namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            var allItemTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => typeof(IItem).IsAssignableFrom(x) && !x.IsAbstract)
                .ToArray();

            var itemType = allItemTypes.FirstOrDefault(x => x.Name == type);
            if (itemType == null)
            {
                throw new InvalidOperationException($"Invalid item type!");
            }

            var item = (IItem)Activator.CreateInstance(itemType);

            return item;
        }
    }
}
