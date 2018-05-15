using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
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

    public void Swap(int indexOne, int indexTwo)
    {
        var firstIndex = data[indexOne];
        var secondIndex = data[indexTwo];

        data[indexOne] = secondIndex;
        data[indexTwo] = firstIndex;
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var element in data)
        {
            sb.AppendLine($"{typeof(T).FullName}: {element}");
        }
        return sb.ToString().Trim();
    }
}

