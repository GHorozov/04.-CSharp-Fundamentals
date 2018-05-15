using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public string Name {get;}

    public int Age { get; }

    public string ID { get; }

    public string BirthDate { get; }

    public Citizen(string name,int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.ID = id;
        this.BirthDate = birthdate;
    }
}

