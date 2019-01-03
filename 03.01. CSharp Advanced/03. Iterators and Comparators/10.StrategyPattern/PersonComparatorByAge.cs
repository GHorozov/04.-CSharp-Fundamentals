﻿using System;
using System.Collections.Generic;
using System.Text;

public class PersonComparatorByAge : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Age.CompareTo(y.Age);

        return result;
    }
}

