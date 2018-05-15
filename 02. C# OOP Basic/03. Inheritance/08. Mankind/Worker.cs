using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) :base(firstName,lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    protected decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if(value < 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }

            this.weekSalary = value;
        }
    }

    protected decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if( value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }

            this.workHoursPerDay = value;
        }
    }

    public decimal GetSalaryPerHour()
    {
        var salaryPerHour = (this.WeekSalary / (this.workHoursPerDay * 5)); 
        return salaryPerHour;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(10);
        sb.AppendLine($"First Name: {base.FirstName}");
        sb.AppendLine($"Last Name: {base.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {GetSalaryPerHour():f2}");

        return sb.ToString();
    }
}

