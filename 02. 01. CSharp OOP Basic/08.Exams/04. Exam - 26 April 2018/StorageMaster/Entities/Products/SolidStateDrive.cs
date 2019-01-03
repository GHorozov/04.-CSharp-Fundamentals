using System;
using System.Collections.Generic;
using System.Text;

public class SolidStateDrive : Product
{
    private const double WeightConst = 0.2;

    public SolidStateDrive(double price) 
        : base(price, WeightConst)
    {
    }
}

