﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MultiplyStrategy : IStartegy
{
    public int Calculate(int first, int second)
    {
        return first * second;
    }
}

