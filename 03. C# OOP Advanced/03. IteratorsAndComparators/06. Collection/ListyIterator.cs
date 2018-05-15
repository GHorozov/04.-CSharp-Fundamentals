using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> collection;
    private int currentIndex;

    public ListyIterator()
    {
        this.currentIndex = 0;
        this.collection = new List<T>();
    }

    public ListyIterator(List<T> collection)
    {
        this.currentIndex = 0;
        this.collection = collection;
    }


    public bool Move()
    {
        if (HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if(this.currentIndex < collection.Count - 1)
        {
            return true;
        }

        return false;
    }


    public T Print()
    {
        if (this.collection.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return this.collection[currentIndex];
    }

    public string PrintAll()
    {
        if (this.collection.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        var sb = new StringBuilder();

        foreach (var name in this.collection)
        {
            sb.Append($"{name} ");
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < collection.Count; i++)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
}

