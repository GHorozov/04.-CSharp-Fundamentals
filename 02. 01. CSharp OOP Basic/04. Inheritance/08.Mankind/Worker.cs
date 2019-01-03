using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    protected decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(this.workHoursPerDay)}");
            }

            this.workHoursPerDay = value;
        }
    }

    protected decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }

            this.weekSalary = value;
        }
    }

    private decimal GetSalaryPerHour()
    {
        var result = (this.WeekSalary / (this.workHoursPerDay * 5));
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {GetSalaryPerHour():f2}");

        return base.ToString() + sb.ToString().TrimEnd();
    }
}

