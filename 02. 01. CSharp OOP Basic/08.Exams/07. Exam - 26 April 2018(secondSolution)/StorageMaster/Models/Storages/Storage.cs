using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] garage;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = InitiateGarageWithVehicle(vehicles);
            this.products = new List<Product>();
        }

        private Vehicle[] InitiateGarageWithVehicle(IEnumerable<Vehicle> vehicles)
        {
            var result = new Vehicle[this.GarageSlots];
            var inputVehicle = vehicles.ToArray();
            for (int i = 0; i < inputVehicle.Length; i++)
            {
                result[i] = inputVehicle[i];
            }

            return result;
        }

        public string Name { get; protected set; }
        public int Capacity { get; protected set; }
        public int GarageSlots { get; protected set; }
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public IReadOnlyCollection<Vehicle> Garage => this.garage;
        public bool IsFull => this.products.Sum(x => x.Weight) >= Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if(garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if(this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            var targetVehicle = this.garage[garageSlot];

            return targetVehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var targetVehicle = GetVehicle(garageSlot);

            if(!deliveryLocation.Garage.Any(x => x == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            var indexOfFreeSlot = Array.IndexOf(deliveryLocation.garage, null);
            deliveryLocation.garage[indexOfFreeSlot] = targetVehicle;

            return indexOfFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var unloadedProducts = 0;
            var currentVahicle = GetVehicle(garageSlot);
            while (true)
            {
                if (this.IsFull)
                {
                    break;
                }
                if (currentVahicle.IsEmpty)
                {
                    break;
                }

                var product = currentVahicle.Unload();
                this.products.Add(product);
                unloadedProducts++;
            }

            return unloadedProducts;
        }
    }
}
