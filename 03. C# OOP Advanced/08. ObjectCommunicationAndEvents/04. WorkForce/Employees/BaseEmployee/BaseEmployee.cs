using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class BaseEmployee
{
    public BaseEmployee(string name, int hoursPerWeek)
    {
        this.Name = name;
        this.HoursPerWeek = hoursPerWeek;
    }

    public string Name { get; private set; }

    public int HoursPerWeek { get; private set; }
}

