using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Job
{
    public delegate void JobDoneEventhandler(object sender, JobsEventArgs e);

    public event JobDoneEventhandler JobDone;

    public Job(string name, int workHoursPerWeekRequared, BaseEmployee employee)
    {
        this.Name = name;
        this.WorkHoursPerWeekRequared = workHoursPerWeekRequared;
        this.Employee = employee;
        this.IsDone = false;
    }


    public string Name { get;  set; }
    public int WorkHoursPerWeekRequared { get; private set; }
    public BaseEmployee Employee { get; private set; }
    public bool IsDone { get; private set; }

    public void Update()
    {
        this.WorkHoursPerWeekRequared -= this.Employee.HoursPerWeek;
        if (this.WorkHoursPerWeekRequared <= 0 && this.IsDone == false)
        {
            if (JobDone != null)
            {
                JobDone(this, new JobsEventArgs(this));
            }
        }
    }

    public void OnJobDone(object sender, EventArgs e)
    {
        Console.WriteLine($"Job {this.Name} done!");
        this.IsDone = true;
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursPerWeekRequared}";
    }
}

