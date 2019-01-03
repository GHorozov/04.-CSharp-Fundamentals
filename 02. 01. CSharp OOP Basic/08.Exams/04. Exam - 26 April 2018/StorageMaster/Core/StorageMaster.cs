namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private List<Storage> storages;
        private List<Product> products;
        private List<Vehicle> vehicles;
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.storages = new List<Storage>();
            this.products = new List<Product>();
            this.vehicles = new List<Vehicle>();
            this.productFactory = new ProductFactory();
            this.vehicleFactory = new VehicleFactory();
            this.storageFactory = new StorageFactory();
            this.currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            var product = productFactory.CreateProduct(type, price);
            this.products.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storages.FirstOrDefault(x => x.Name == storageName);
            if (currentStorage == null)
            {
                throw new InvalidOperationException("Selected storage is not found!");
            }

            this.currentVehicle = currentStorage.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle}";

        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            foreach (var productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                var product = this.products.LastOrDefault(x => x.GetType().Name == productName);
                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                this.products.Remove(product);
                this.currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storages.FirstOrDefault(x => x.Name == sourceName);
            var destinationStorage = this.storages.FirstOrDefault(x => x.Name == destinationName);
            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var targetVehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {targetVehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var targetStorage = this.storages.FirstOrDefault(x => x.Name == storageName);
            var targetVahicle = targetStorage.GetVehicle(garageSlot);
            var productsInVehicle = targetVahicle.Trunk.Count();
            var unloadedProductsCount = targetStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var targetStorage = this.storages.FirstOrDefault(x => x.Name == storageName);
            if (targetStorage == null)
            {
                throw new InvalidOperationException("Target storage is not found!");
            }

            var sumOfProductsWeight = targetStorage.Products.Sum(x => x.Weight);
            var storageCapacity = targetStorage.Capacity;

            var stockInfo = targetStorage.Products
                .GroupBy(x => x.GetType().Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ({x.Count})")
                .ToArray();

            var allVehicleInGarage = targetStorage.Garage.ToArray();
            var garageInfo = new List<string>();
            for (int i = 0; i < allVehicleInGarage.Length; i++)
            {
                var currentVehicle = allVehicleInGarage[i];
                if (currentVehicle == null)
                {
                    garageInfo.Add("empty");
                }
                else
                {
                    garageInfo.Add(currentVehicle.GetType().Name);
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Stock ({sumOfProductsWeight}/{storageCapacity}): [{string.Join(", ", stockInfo)}]");
            sb.AppendLine($"Garage: [{string.Join("|", garageInfo)}]");

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();
            var allStorages = this.storages.OrderByDescending(x => x.Products.Sum(s => s.Price));

            foreach (var storage in allStorages)
            {
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(s => s.Price):f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

