namespace StorageMaster.Models.Storages
{
    using global::StorageMaster.Models.Vehicles;
    using System.Collections.Generic;

    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;
        private static Vehicle[] vehicles = new Vehicle[] { new Semi(), new Semi(), new Semi() };

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
