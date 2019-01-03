namespace StorageMaster.Models.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Van : Vehicle
    {
        private const int DefaultCapacity = 2;

        public Van() 
            : base(DefaultCapacity)
        {
        }
    }
}
