using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Storage
{
    private bool isFull;
    private Vehicle[] garage;
    private List<Product> products;

    public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.GarageSlots = garageSlots;
        this.garage = InitiateGarageWithVehicle(vehicles);
        this.products = new List<Product>();
    }

    public string Name { get; protected set; }
    public int Capacity { get; protected set; }
    public int GarageSlots { get; protected set; }
    public bool IsFull
    {
        get
        {
            var allProductsWeight = this.products.Sum(x => x.Weight);
            if (allProductsWeight >= this.Capacity)
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
    public IReadOnlyCollection<Vehicle> Garage => this.garage;
    public IReadOnlyCollection<Product> Products => this.products;

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

    public Vehicle GetVehicle(int garageSlot)
    {
        if (garageSlot < 0 || garageSlot >= this.GarageSlots)
        {
            throw new InvalidOperationException("Invalid garage slot!");
        }

        if (this.garage[garageSlot] == null)
        {
            throw new InvalidOperationException("No vehicle in this garage slot!");
        }

        var result = this.garage[garageSlot];
        
        return result;
    }

    public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
    {
        Vehicle currentVehicle = GetVehicle(garageSlot);

        if (!deliveryLocation.garage.Any(x => x == null))
        {
            throw new InvalidOperationException("No room in garage!");
        }

        this.garage[garageSlot] = null;
        var indexOFFreeSpot = Array.IndexOf(deliveryLocation.garage, null);
        deliveryLocation.garage[indexOFFreeSpot] = currentVehicle;

        return indexOFFreeSpot;
    }

    public int UnloadVehicle(int garageSlot)
    {
        if (this.IsFull)
        {
            throw new InvalidOperationException("Storage is full!");
        }

        var targetVehicle = GetVehicle(garageSlot);
        var countUnloadedProducts = 0;
        while (true)
        {
            if (targetVehicle.IsEmpty) break;
            if (this.IsFull) break;

            this.products.Add(targetVehicle.Unload());
            countUnloadedProducts++;
        }

        return countUnloadedProducts;
    }
}

