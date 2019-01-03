using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

public class StorageFactory
{
    public Storage CreateStorage(string type, string name)
    {
        Storage storage = null;
        if(type == "DistributionCenter")
        {
            storage = new DistributionCenter(name);
        }
        else if (type == "AutomatedWarehouse")
        {
            storage = new AutomatedWarehouse(name);
        }
        else if(type == "Warehouse")
        {
            storage = new Warehouse(name);
        }
        else
        {
            throw new InvalidOperationException("Invalid storage type!");
        }

        return storage;
    }
}

