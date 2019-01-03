namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;

    public class Backpack : Bag
    {
        private const int ConstDefaultCapacity = 100;

        public Backpack() 
            : base(ConstDefaultCapacity)
        {
        }
    }
}
