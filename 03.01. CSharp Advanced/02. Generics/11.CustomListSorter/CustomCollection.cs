using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomCollection<T>
            where T: IComparable
{
    private List<T> items;

    public CustomCollection()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public void Remove(int index)
    {
        this.items.RemoveAt(index);
    }

    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var temp = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = temp;
    }

    public int Greater<T>(T element)
    {
        var result = 0;
        foreach (var item in this.items)
        {
            if (item.CompareTo(element) > 0)
            {
                result++;
            }
        }

        return result;
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }

    public void Sort()
    {
        this.items = this.items.OrderBy(x => x).ToList();
    }

    public string Print()
    {
        var sb = new StringBuilder();
        foreach (var item in this.items)
        {
            sb.AppendLine($"{item}");
        }

        return sb.ToString().TrimEnd();
    }
}

