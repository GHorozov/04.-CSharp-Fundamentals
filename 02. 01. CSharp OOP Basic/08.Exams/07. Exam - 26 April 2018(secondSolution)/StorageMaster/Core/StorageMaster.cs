namespace StorageMaster
{
    using global::StorageMaster.Models.Products;
    using global::StorageMaster.Models.Storages;
    using global::StorageMaster.Models.Vehicles;
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
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.storages = new List<Storage>();
            this.products = new List<Product>();
            this.vehicles = new List<Vehicle>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.products.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storages.FirstOrDefault(x => x.Name == storageName);
            var vehicleType = currentStorage.GetVehicle(garageSlot);
            this.currentVehicle = vehicleType;

            return $"Selected {vehicleType.GetType().Name}";
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

                if (!this.products.Any(x => x.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                var targetProduct = this.products.LastOrDefault(x => x.GetType().Name == productName);
                this.products.Remove(targetProduct);
                this.currentVehicle.LoadProduct(targetProduct);
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
            var currentStorage = this.storages.FirstOrDefault(x => x.Name == storageName);

            var targetVehicle = currentStorage.GetVehicle(garageSlot);
            var productsInVehicle = targetVehicle.Trunk.Count();
            var unloadedProductsCount = currentStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var sb = new StringBuilder();
            var targetStorage = this.storages.FirstOrDefault(x => x.Name == storageName);
            var sumOfProducts = targetStorage.Products.Sum(x => x.Weight);
            var storageCapacity = targetStorage.Capacity;
            var productList = targetStorage
                .Products
                .GroupBy(x => x.GetType().Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ({x.Count})")
                .ToList();

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

            sb.AppendLine($"Stock ({sumOfProducts}/{storageCapacity}): [{string.Join(", ", productList)}]");
            sb.AppendLine($"Garage: [{string.Join("|", garageInfo)}]");

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();
            var orderStorages = this.storages.OrderByDescending(x => x.Products.Sum(p => p.Price));

            foreach (var item in orderStorages)
            {
                sb.AppendLine($"{item.Name}:");
                sb.AppendLine($"Storage worth: ${item.Products.Sum(x => x.Price):F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
