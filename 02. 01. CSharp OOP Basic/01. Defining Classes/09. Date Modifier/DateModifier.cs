using System;
using System.Globalization;

public class DateModifier
{
    private string firstDate;
    private string secondDate;

    public DateModifier(string firstDate, string secondDate)
    {
        this.firstDate = firstDate;
        this.secondDate = secondDate;
    }

    public int GetDifference()
    {
        var date1 = DateTime.ParseExact(this.firstDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        var date2 = DateTime.ParseExact(this.secondDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);

        TimeSpan result = date1 - date2;

        return Math.Abs(result.Days);
    }
}