using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

public class DistributionCenter :Storage
{
    private const int CapacityConst = 2;
    private const int StorageSlotsConst = 5;
    private static IReadOnlyCollection<Vehicle> list = new ReadOnlyCollection<Vehicle>(new[] 
    {
        new Van(),
        new Van(),
        new Van()
    });

    public DistributionCenter(string name) 
        : base(name, CapacityConst, StorageSlotsConst, list)
    {
    }
}

