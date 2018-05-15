﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;     //To use validation i must take fields through properties
        this.LastName = lastName;
        this.Age = age;
    }

    public Person(string firsrName, string lastName, int age, double salary) : this(firsrName, lastName, age)
    {
        this.Salary = salary;
    }
    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = value;
        }
    }
    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value  .Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if(value < 460)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.salary = value;
        }
    }

    public void IncreaseSalary(double bonus)
    {
        if(this.age < 30)
        {
             this.salary += this.salary * bonus/200;
        }
        else
        {
             this.salary += this.salary * bonus/100;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }
}
