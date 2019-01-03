using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T,U,K>
{
    public Threeuple(T item1, U item2, K item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public T Item1 { get; set; }
    public U Item2 { get; set; }
    public K Item3 { get; set; }
}

