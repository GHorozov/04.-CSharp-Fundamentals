using System;

public interface IDateTime
{
    DateTime Now();

    void AddDays(DateTime date, double days);

    TimeSpan SubstractDays(DateTime date, int days);
}

