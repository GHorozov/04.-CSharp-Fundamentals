using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PartTimeEmployee :BaseEmployee
{
    private const int HoursPerWeekC = 20; 

    public PartTimeEmployee(string name) : base(name, HoursPerWeekC)
    {

    }

}

