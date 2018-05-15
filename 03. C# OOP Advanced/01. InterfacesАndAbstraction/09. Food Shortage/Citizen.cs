using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : ICreature, IBuyer
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Id { get; }
    public string Name { get; }
    public int Age { get; }
    public string Birthdate { get; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

