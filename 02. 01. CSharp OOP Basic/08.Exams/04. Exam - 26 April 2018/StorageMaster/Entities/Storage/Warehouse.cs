using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

public class Warehouse :Storage
{
    private const int CapacityConst = 10;
    private const int StorageSlotsConst = 10;
    private static IReadOnlyCollection<Vehicle> list = new ReadOnlyCollection<Vehicle>(new[]
    {
       new Semi(),
       new Semi(),
       new Semi()
    });

    public Warehouse(string name) 
        : base(name, CapacityConst, StorageSlotsConst, list)
    {
    }
}

