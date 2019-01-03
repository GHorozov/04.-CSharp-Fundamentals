namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using DungeonsAndCodeWizards.Models.Characters;

    public abstract class Item
    {
        public Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; protected set; }

        public abstract void AffectCharacter(Character character);
    }
}
