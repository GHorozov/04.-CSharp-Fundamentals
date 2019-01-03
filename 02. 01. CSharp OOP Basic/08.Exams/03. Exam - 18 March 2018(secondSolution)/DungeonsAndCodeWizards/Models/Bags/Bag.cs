namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;
    using DungeonsAndCodeWizards.Models.Items;
    using System.Collections.Generic;
    using System.Linq;
    using OutputMessages;

    public abstract class Bag
    {
        private const int ConstDefaultCapacity = 100;
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; protected set; }
        public double Load => this.items.Sum(x => x.Weight);
        public IReadOnlyCollection<Item> Items => this.items;
        public bool IsEmpty => !this.Items.Any();

        public void AddItem(Item item)
        {
            if((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.BagIsFull);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(OutputMessages.BagIsEmpty);
            }

            if(!this.Items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(OutputMessages.NoItemWithThisNameInTheBag, name));
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
