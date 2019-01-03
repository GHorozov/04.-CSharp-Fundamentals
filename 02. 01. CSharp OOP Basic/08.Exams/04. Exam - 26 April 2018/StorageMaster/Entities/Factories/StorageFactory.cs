using System;
using System.Collections.Generic;
using System.Text;

public class StorageFactory
{
    public Storage CreateStorage(string type, string name)
    {
        Type storageType = Type.GetType(type);
        if(storageType == null || type == "Storage")
        {
            throw new InvalidOperationException("Invalid storage type!");
        }

        Storage storage = null;
        try
        {
            storage = (Storage)Activator.CreateInstance(storageType, new object[] { name });
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.InnerException.Message);
        }

        return storage;
    }
}

