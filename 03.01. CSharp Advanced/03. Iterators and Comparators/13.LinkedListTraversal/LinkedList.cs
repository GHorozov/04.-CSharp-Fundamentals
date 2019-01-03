using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{
    private IList<T> collection;

    public LinkedList()
    {
        this.collection = new List<T>();
    }

    public int Count  => this.collection.Count;

    public void Add(T number)
    {
        this.collection.Add(number);
    }

    public bool Remove(T number)
    {
        if(this.collection.Contains(number))
        {
            this.collection.Remove(number);
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

