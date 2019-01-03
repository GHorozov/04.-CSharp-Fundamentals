using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake<T> : IEnumerable<T>
{
    private IReadOnlyList<T> collection;

    public Lake(IReadOnlyList<T> collection)
    {
        this.collection = collection;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i += 2)
        {
            yield return this.collection[i];
        }

        var lastIndex = (this.collection.Count - 1) % 2 == 0 ? (this.collection.Count - 2) : (this.collection.Count - 1);

        for (int i = lastIndex; i >= 0; i -= 2)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

