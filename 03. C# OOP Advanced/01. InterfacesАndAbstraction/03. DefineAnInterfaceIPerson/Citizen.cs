using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Citizen : IPerson
{
    public string Name {get;}

    public int Age { get; }


    public Citizen(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

