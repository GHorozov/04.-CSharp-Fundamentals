using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Company
{
    private string name;
    private decimal selary;

    public Company(string name, decimal selary)
    {
        this.name = name;
        this.selary = selary;
    }

    public string Name
    {
        get {return this.name; }
    }

    public decimal Selery
    {
        get {return this.selary; }
    }
}

