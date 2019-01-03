using System;
using System.Collections.Generic;
using System.Text;

public class HardDrive : Product
{
    private const double WeightConst = 1;

    public HardDrive(double price) 
        : base(price, WeightConst)
    {
    }
}

