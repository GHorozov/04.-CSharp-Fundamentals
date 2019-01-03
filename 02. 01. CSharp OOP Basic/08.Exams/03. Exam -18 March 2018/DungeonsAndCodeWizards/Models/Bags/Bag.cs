using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    private const int DefaultCapacity = 100;
    private List<Item> items;

    public Bag(int capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    public int Capacity { get; private set; }
    public double Load => this.items.Select(x => x.Weight).Sum();
    public IReadOnlyCollection<Item> Items => this.items;

    public void AddItem(Item item)
    {
        if ((this.Load + item.Weight) > this.Capacity)
        {
            throw new InvalidOperationException(OutputMessage.BagIsFull);
        }

        this.items.Add(item);
    }


    public Item GetItem(string name)
    {
        if (!this.Items.Any())
        {
            throw new InvalidOperationException(OutputMessage.BagIsEmpty);
        }

        var currentItem = this.Items.FirstOrDefault(x => x.GetType().Name == name);
        if (currentItem == null)
        {
            throw new ArgumentException(string.Format(OutputMessage.NoItemWithName, name));
        }

        this.items.Remove(currentItem);

        return currentItem;
    }


}

