using System;
using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    public AddCollection()
    {
        this.Data = new List<string>();
    }

    protected List<string> Data { get; set; }

    public virtual int Add(string item)
    {
        var currentLastIndex = this.Data.Count;
        this.Data.Add(item);
        return currentLastIndex;
    }
}

