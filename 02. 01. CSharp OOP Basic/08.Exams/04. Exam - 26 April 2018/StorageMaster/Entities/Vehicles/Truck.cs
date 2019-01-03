using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    private const int CapacityConst = 5;

    public Truck() 
        : base(CapacityConst)
    {
    }
}

