namespace StorageMaster.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ram : Product
    {
        private const double ConstWeight = 0.1;

        public Ram(double price) 
            : base(price, ConstWeight)
        {
        }
    }
}
