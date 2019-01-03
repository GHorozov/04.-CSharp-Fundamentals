namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;

    public class Satchel : Bag
    {
        private const int ConstDefaultCapacity = 20;

        public Satchel()
            : base(ConstDefaultCapacity)
        {
        }
    }
}
