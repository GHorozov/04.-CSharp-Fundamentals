using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PersonCompareByName : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            result = x.Name.ToLower().FirstOrDefault().CompareTo(y.Name.ToLower().FirstOrDefault());
        }

        return result;
    }
}

