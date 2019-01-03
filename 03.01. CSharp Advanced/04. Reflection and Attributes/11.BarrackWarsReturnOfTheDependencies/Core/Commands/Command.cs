using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command : IExecutable
{
    private string[] data;
   
    public Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; private set; }

    public abstract string Execute();
}

