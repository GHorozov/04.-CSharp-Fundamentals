using System;
using System.Collections.Generic;
using System.Text;

public class PersonCompatorByNames : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            var firstLetterX = x.Name[0].ToString().ToLower();
            var firstLetterY = y.Name[0].ToString().ToLower();

            result = firstLetterX.CompareTo(firstLetterY);
        }

        return result;
    }
}

