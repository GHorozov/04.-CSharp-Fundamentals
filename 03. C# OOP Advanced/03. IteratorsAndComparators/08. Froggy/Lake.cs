using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Lake<T> : IEnumerable<T>
{
    private readonly List<T> stones;


    public Lake(List<T> collection)
    {
        this.stones = collection;
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i += 2)
        {
            yield return this.stones[i];
        }

        var lastIndex = (this.stones.Count - 1) % 2 == 0 ? (this.stones.Count - 2) : (this.stones.Count - 1);

        for (int i = lastIndex; i >= 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

}

