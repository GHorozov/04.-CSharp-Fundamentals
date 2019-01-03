using System;
using System.Collections.Generic;
using System.Text;

public class Bubble
{
    private List<int> collection;

    public Bubble(List<int> collection)
    {
        this.Collection = collection;
    }

    public List<int> Collection
    {
        get
        {
            return this.collection;
        }
        private set
        {
            if(value.Count == 0)
            {
                throw new InvalidOperationException("Input is empty!");
            }

            this.collection = value;
        }
    }

    public List<int> BubbleSort()
    {
        while (true)
        {
            var isDone = true;
            for (int i = 0; i < this.Collection.Count - 1; i++)
            {
                for (int j = i + 1; j < this.Collection.Count; j++)
                {
                    var left = this.Collection[i];
                    var right = this.Collection[j];

                    if (left > right)
                    {
                        this.Collection[i] = right;
                        this.Collection[j] = left;
                        isDone = false;
                    }
                }
            }

            if (isDone) break;
        }

        return this.Collection;
    }
}

