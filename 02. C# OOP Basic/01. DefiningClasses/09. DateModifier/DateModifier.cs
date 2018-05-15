using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DateModifier
{
    private DateTime firstDate;
    private DateTime secondDate;

    public DateModifier(DateTime firstDate, DateTime secondDate)
    {
        this.firstDate = firstDate;
        this.secondDate = secondDate;
    }

    public DateTime FirstDate
    {
        get
        {
            return this.firstDate;
        }
        set
        {
            this.firstDate = value;
        }
    }
    public DateTime SecondDate
    {
        get
        {
            return this.secondDate;
        }
        set
        {
            this.secondDate = value;
        }
    }

    public double GetTwoDatesDiffrance()
    {
        TimeSpan diff = this.firstDate - this.secondDate;
        var result = Math.Abs(diff.Days);

        return result;
    }
}

