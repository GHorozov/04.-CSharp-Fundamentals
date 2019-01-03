using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private int[] collection;

    public Database(int[] collection)
    {
        this.Collection = collection;
    }

    public int[] Collection
    {
        get
        {
            return this.collection;
        }
        private set
        {
            if (value.Length != 16)
            {
                throw new InvalidOperationException("Collection lenght wrong!");
            }

            this.collection = value;
        }
    }

    public void Add(int number)
    {
        var isFull = true;
        for (int i = 0; i < this.collection.Length; i++)
        {
            if (this.collection[i] == 0)
            {
                this.collection[i] = number;
                isFull = false;
                break;
            }
        }

        if (isFull)
        {
            throw new InvalidOperationException("The collection is full!");
        }
    }

    public void Remove()
    {
        if (this.Collection.All(x => x == 0))
        {
            throw new InvalidOperationException("The collection is empty!");
        }

        for (int i = this.Collection.Length - 1; i >= 0; i--)
        {
            if (this.Collection[i] != 0)
            {
                this.Collection[i] = 0;
                break;
            }
        }
    }

    public int[] Fetch()
    {
        return this.Collection;
    }
}

