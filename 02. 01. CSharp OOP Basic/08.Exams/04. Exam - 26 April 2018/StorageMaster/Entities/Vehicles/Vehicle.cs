using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Vehicle
{
    private int capacity;
    private List<Product> trunk;
    private bool isFull;
    private bool isEmpty;

    public Vehicle(int capacity)
    {
        this.Capacity = capacity;
        this.trunk = new List<Product>();
    }

    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public IReadOnlyCollection<Product> Trunk => this.trunk;

    public bool IsFull
    {
        get
        {
            var productsWeights = this.Trunk.Sum(x => x.Weight);
            if (productsWeights >= this.Capacity)
            {
                return true;
            }

            return this.isFull;
        }
        protected set
        {
            this.isFull = value;
        }
    }

    public bool IsEmpty
    {
        get
        {
            if (!this.Trunk.Any())
            {
                return true;
            }

            return this.isEmpty;
        }
        protected set
        {
            this.isEmpty = value;
        }
    }

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

        var productToReturn = this.Trunk.Last();
        this.trunk.Remove(productToReturn);

        return productToReturn;
    }
}

