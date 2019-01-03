namespace StorageMaster.Models.Vehicles
{
    using global::StorageMaster.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vehicle
    {
        private List<Product> trunk;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; protected set; }
        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();
        public bool IsFull => this.trunk.Sum(x => x.Weight) >= this.Capacity;
        public bool IsEmpty => !this.trunk.Any(); 

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var product = this.trunk.Last();
            this.trunk.Remove(product);

            return product;
        }
    }
}
