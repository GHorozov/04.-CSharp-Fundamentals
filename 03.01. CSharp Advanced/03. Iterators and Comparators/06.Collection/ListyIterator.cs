using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> :IEnumerable<T>
{
    private IReadOnlyList<T> collection;
    private int index;

    public ListyIterator(IReadOnlyList<T> collection)
    {
        this.collection = collection;
        this.index = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            this.index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return index < this.collection.Count-1;
    }

    public void Print()
    {
        if(this.index >=0 && this.index <= this.collection.Count - 1)
        {
            Console.WriteLine(this.collection[this.index]);
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.collection));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

