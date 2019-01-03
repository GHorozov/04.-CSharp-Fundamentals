using System;

public class ItemFactory
{
    public Item CreateItem(string itemName)
    {
        Item item = null;
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
                throw new ArgumentException(string.Format(OutputMessage.InvalidItem, itemName));
        }

        return item;
    }
}

