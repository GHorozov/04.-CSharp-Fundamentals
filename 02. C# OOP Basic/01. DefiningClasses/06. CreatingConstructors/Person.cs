using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    public string name = "No name"; //I set default name to be "No name".
    public int age = 1; //I set default age to be equal to 1.

    public Person() //Empty contsructor
    {

    }

    public Person(int age) //Constructor with only one parameter age that will be pass by user.
    {
        this.age = age;
    }
    public Person(string name, int age) : this(age) //Take age data from prev. constructor.
    {
        this.name = name;
    }
}

