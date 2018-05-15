using System;
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
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person(string firsrName, string lastName, int age, double salary) : this(firsrName, lastName, age)
    {
        this.salary = salary;
    }
    public string FirstName
    {
        get { return this.firstName; }
    }
    public int Age
    {
        get { return this.age; }
    }

    public void IncreaseSalary(double bonus)
    {
        if (this.age < 30)
        {
            this.salary += this.salary * bonus / 200;
        }
        else
        {
            this.salary += this.salary * bonus / 100;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }
}

