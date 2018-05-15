using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StandartEmployee : BaseEmployee
{
    private const int HoursPerWeekC = 40;

    public StandartEmployee(string name) : base(name, HoursPerWeekC)
    {
    }
}

