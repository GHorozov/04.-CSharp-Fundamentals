using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat
{
    public Cat(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}
