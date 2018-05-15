using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ferrari : ICar
{
    public Ferrari(string name)
    {
        this.Name = name;
        this.Model = "488-Spider";
    }

    public string Name { get; private set; }

    public string Model { get; private set; }

    public string Break()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{Break()}/{Gas()}/{this.Name}";
    }
}

