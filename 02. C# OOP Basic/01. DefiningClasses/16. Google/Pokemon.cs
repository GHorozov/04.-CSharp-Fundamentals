using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Pokemon
{
    private string name;

    public Pokemon(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return this.name; }
    }
}

