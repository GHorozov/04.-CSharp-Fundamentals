using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    private const int indexAddNewElement = 0;

    public override int Add(T element)
    {
        this.Data.Insert(indexAddNewElement, element);
        return indexAddNewElement;
    }

    public virtual T Remove()
    {
        var lastElement = this.Data.Last();
        this.Data.RemoveAt(this.Data.Count - 1);
        return lastElement;
    }
}

