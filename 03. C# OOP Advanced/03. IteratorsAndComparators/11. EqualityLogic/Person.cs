using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }


    public int CompareTo(Person other) //compare first by name and thenif equal by age 
    {
        var result = this.Name.CompareTo(other.Name);

        if(result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }
}

