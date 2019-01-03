﻿using System;
using System.Collections.Generic;
using System.Text;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        var result = x.Title.CompareTo(y.Title);

        if (result == 0)
        {
            result = y.Year.CompareTo(x.Year); //for descending order change y and x places, to acending x amd y
        }

        return result;
    }
}

