using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListIterator
{
    private List<string> collection;
    private int index;

    public ListIterator(List<string> collection)
    {
        this.Collection = collection;
        this.Index = 0;
    }

    public List<string> Collection
    {
        get
        {
            return this.collection;
        }
        private set
        {
            if (value.Contains(null))
            {
                throw new ArgumentNullException("Cannot have null in collection.");
            }

            this.collection = value;
        }
    }

    public int Index { get; private set; }

    public bool Move()
    {
        if (!HasNext())
        {
            return false;
        }

        this.Index++;

        return true;
    }

    public void Print()
    {
        if (!this.Collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.Collection[this.Index]);
    }

    public bool HasNext()
    {
        if(this.Collection.Count-1 == this.Index)
        {
            return false;
        }

        return true;
    }
}

