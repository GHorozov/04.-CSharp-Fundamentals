using System;
using System.Collections.Generic;
using System.Text;

public class Ram : Product
{
    private const double WeightConst = 0.1;

    public Ram(double price) 
        : base(price, WeightConst)
    {
    }
}

