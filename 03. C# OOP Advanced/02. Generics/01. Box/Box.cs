using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
{
    private IList<T> data;
    public int Count => this.data.Count;

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var oldValue = this.data[data.Count - 1];
        this.data.RemoveAt(data.Count - 1);

        return oldValue;
    }

}

