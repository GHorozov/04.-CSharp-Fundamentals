namespace StorageMaster.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SolidStateDrive : Product
    {
        private const double ConstWeight = 0.2;

        public SolidStateDrive(double price)
            : base(price, ConstWeight)
        {
        }
    }
}
