using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Pokemon
{
    //name, an element and health
    private string name;
    private string element;
    private int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public string Name
    {
        get { return this.name; }
    }
    public string Element
    {
        get { return this.element; }
    }
    public int Health
    {
        get { return this.health; }
    }

    public void ReduceHealth()
    {
        this.health -= 10;
    }
}

