namespace StorageMaster.Models.Storages
{
    using global::StorageMaster.Models.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;
        private static Vehicle[] vehicles = new Vehicle[] { new Truck() };

        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
