using System;
using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection: AddCollection, IAddRemoveCollection
{
    private const int StartIndex = 0;
 
    public override int Add(string item)
    {
        this.Data.Insert(StartIndex, item);
        return StartIndex;
    }

    public virtual string Remove()
    {
        var lastElement = this.Data.Last();
        this.Data.RemoveAt(this.Data.Count - 1);
        return lastElement;
    }
}

