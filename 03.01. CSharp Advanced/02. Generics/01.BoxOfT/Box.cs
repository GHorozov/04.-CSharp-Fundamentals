using System.Collections.Generic;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count => this.items.Count;

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove()
    {
        var oldValue = this.items[items.Count - 1];
        this.items.RemoveAt(items.Count - 1);

        return oldValue;
    }
}

