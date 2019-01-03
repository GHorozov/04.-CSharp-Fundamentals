namespace DungeonsAndCodeWizards.Models.Factories
{
    using System;
    using System.Linq;
    using DungeonsAndCodeWizards.Models.Items;
    using OutputMessages;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Item item;
            switch (itemName)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException(string.Format(OutputMessages.IvalidItemType, itemName));
            }

            return item;

            //Second way - reflection:
            //var type = this.GetType()
            //    .Assembly
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == itemName);

            //if(type == null || itemName == "Item" || String.IsNullOrWhiteSpace(itemName))
            //{
            //    throw new ArgumentException(string.Format(OutputMessages.IvalidItemType, itemName));
            //}

            //try
            //{
            //    var item = (Item)Activator.CreateInstance(type, new object[] { });
            //    return item;
            //}
            //catch (Exception ex)
            //{
            //    throw new InvalidOperationException(ex.Message);
            //}
        }
    }
}
