using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Stack<T> : IEnumerable<T>
{
    private readonly List<T> collection;
    private int index;

    public Stack()
    {
        this.collection = new List<T>();

    }

    public void Push(List<T> elements)
    {
        foreach (var element in elements)
        {
            this.collection.Add(element);
        }
    }

    public void Pop()
    {
        if(collection.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        var last = this.collection.Last();
        this.collection.Remove(last);
    }

    public string Print()
    {
        var sb = new StringBuilder();
        for (int i = collection.Count - 1; i >= 0; i--)
        {
            sb.AppendLine($"{collection[i]}");
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
}

