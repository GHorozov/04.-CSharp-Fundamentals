using System;
using System.Collections.Generic;

public class MyList : AddRemoveCollection, IMyList
{
    private const int StartIndex = 0;

    public override string Remove()
    {
        var currentItem = this.Data[StartIndex];
        this.Data.RemoveAt(StartIndex);
        return currentItem;
    }

    public int Used()
    {
        return this.Data.Count;
    }
}

