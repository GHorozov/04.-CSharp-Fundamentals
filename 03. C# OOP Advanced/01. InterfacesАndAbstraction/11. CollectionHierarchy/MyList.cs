using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    private const int RemoveIndex = 0;

    public IList<T> Used
    {
        get
        {
            return this.Data as List<T>;
        }
    }

    public override T Remove()
    {
        var firstElement = this.Data.First();
        this.Data.RemoveAt(RemoveIndex);
        return firstElement;
    }
}

