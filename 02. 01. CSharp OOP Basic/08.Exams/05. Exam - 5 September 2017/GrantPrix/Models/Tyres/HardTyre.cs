using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre : Tyre
{
    private const string ConstName = "Hard";

    public HardTyre(double hardness) 
        : base(ConstName, hardness)
    {
    }
}

