using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable
{
    private List<T> list;

    public Box()
    {
        this.list = new List<T>();
    }

    public void AddItem(T element)
    {
        this.list.Add(element);
    }

    public void SwapElements<T>(int index1, int index2)
    {
        var temp = this.list[index1];
        this.list[index1] = this.list[index2];
        this.list[index2] = temp;
    }

    public int CompareByValue<T>(T elementToCompareWith)
    {
        var result = 0;
        foreach (var item in this.list)
        {
            if(item.CompareTo(elementToCompareWith) > 0)
            {
                result++;
            }
        }

        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in this.list)
        {
            sb.AppendLine($"{item.GetType().FullName}: {item}");
        }

        return sb.ToString().TrimEnd();
    }
}

