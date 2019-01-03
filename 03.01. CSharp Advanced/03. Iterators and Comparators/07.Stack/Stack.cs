using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private List<T> collection;

    public Stack(params T[] collection)
    {
        this.collection = new List<T>(collection);
    }

    public void Push(params T[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            this.collection.Add(items[i]);
        }
    }

    public T Pop()
    {
        if(this.collection.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var popedElement = this.collection[this.collection.Count - 1];
        this.collection.RemoveAt(this.collection.Count - 1);
        return popedElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.collection.Count - 1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

