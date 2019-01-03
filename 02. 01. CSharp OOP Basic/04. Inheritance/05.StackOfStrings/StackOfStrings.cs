using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = data[data.Count - 1];
            data.RemoveAt(data.Count-1);
        }

        return element;
    }

    public string Peek()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = data[data.Count - 1];
        }

        return element;
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}

