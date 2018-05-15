using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
{
    private T name { get; set; }

    public Box(T name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {name}";
    }
}

