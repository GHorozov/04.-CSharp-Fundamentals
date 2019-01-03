namespace StorageMaster.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gpu : Product
    {
        private const double ConstWeight = 0.7;

        public Gpu(double price) 
            : base(price, ConstWeight)
        {
        }
    }
}
