using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LinkedList<T> : IEnumerable<T>
{
    private List<T> list;

    public LinkedList()
    {
        this.list = new List<T>();
    }

    public void Add(T element)
    {
        list.Add(element);
    }

    public bool Remove(T element)
    {
        if (!this.list.Contains(element))
        {
            return false;
        }

        this.list.Remove(element);
        return true; 
    }

    public int Count()
    {
        return this.list.Count();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

