using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person : IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Town { get; set; }

    public Person()
    {

    }

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);

        if(result == 0)
        {
            result = this.Age.CompareTo(other.Age);
            if(result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }
        }

        return result;
    }
}

