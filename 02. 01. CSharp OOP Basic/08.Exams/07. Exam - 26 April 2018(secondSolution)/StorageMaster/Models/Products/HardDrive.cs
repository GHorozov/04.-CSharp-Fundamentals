namespace StorageMaster.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HardDrive : Product
    {
        private const double ConstWeight = 1;

        public HardDrive(double price) 
            : base(price, ConstWeight)
        {
        }
    }
}
