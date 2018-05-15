using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EqualityComperator : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y) //compare object with object
    {
        return x.CompareTo(y) == 0;
    }

    public int GetHashCode(Person person) //return how to print 
    {
        return $"{person.Name} {person.Age}".GetHashCode();
    }
}

