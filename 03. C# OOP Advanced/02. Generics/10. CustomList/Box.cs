using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
    where T : IComparable<T>
{
    private List<T> data { get; set; }

    public Box()
    {
        this.data = new List<T>();
    }

    public void AddElement(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        var oldValue = this.data[index];
        this.data.RemoveAt(index);

        return oldValue;
    }

    public void Swap(int indexOne, int indexTwo)
    {
        var firstIndex = data[indexOne];
        var secondIndex = data[indexTwo];

        data[indexOne] = secondIndex;
        data[indexTwo] = firstIndex;
    }

    public bool Contains(T element)
    {
        if (this.data.Contains(element))
        {
            return true;
        }

        return false;
    }

    public int Greater(T element)
    {
        var counter = 0;
        foreach (var item in data)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var element in data)
        {
            sb.AppendLine($"{element}");
        }

        return sb.ToString().Trim();
    }
}

