namespace StorageMaster.Models.Storages
{
    using global::StorageMaster.Models.Vehicles;
    using System.Collections.Generic;

    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultGarageSlots = 5;
        private static Vehicle[] vehicles = new Vehicle[] { new Van(), new Van(), new Van() };

        public DistributionCenter(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
