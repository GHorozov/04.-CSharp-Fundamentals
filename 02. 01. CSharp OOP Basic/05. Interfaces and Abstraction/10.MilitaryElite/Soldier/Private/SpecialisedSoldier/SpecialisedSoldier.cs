using System;
using System.Collections.Generic;

public abstract  class SpecialisedSoldier :Private, ISpecialisedSoldier
{
    protected SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
        :base(id, firstName, lastName, salary)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        this.Corps = corps;
    }

    public virtual string Corps { get; set; }
}

