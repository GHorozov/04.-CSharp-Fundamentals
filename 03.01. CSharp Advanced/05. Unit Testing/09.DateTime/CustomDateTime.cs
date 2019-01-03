using System;

public class CustomDateTime : IDateTime
{
    public void AddDays(DateTime date, double days)
    {
        date.AddDays(days);
    }

    public DateTime Now()
    {
        return DateTime.Now;
    }

    public TimeSpan SubstractDays(DateTime date, int days)
    {
        TimeSpan dateResult = date.Subtract(
            DateTime.Parse($"{days}",
            System.Globalization.CultureInfo.InvariantCulture));

        return dateResult;
    }
}

