using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

class AutomatedWarehouse :Storage
{
    private const int CapacityConst = 1;
    private const int StorageSlotsConst = 2;
    private static IReadOnlyCollection<Vehicle> list = new ReadOnlyCollection<Vehicle>(new[]
    {
       new Truck()
    });

    public AutomatedWarehouse(string name) 
        : base(name, CapacityConst, StorageSlotsConst, list)
    {
    }
}

