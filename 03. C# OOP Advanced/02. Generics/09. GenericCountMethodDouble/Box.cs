using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
    where T : IComparable
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

    public int CompareElements(double element)
    {
        var counter = 0;
        foreach (var item in data)
        {
            if(item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}

