using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }

    public override bool Equals(object obj)
    {
        return this.Name == ((Person)obj).Name && this.Age == ((Person)obj).Age;
    }

    public override int GetHashCode()
    {
        return this.Age;
    }
}

