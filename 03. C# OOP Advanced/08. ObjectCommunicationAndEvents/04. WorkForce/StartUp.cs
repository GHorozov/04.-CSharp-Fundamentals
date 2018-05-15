using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public delegate void JobDoneEventhandler(object sender, JobsEventArgs e);

    public static void Main(string[] args)
    {
        JobsList jobs = new JobsList();
        List<BaseEmployee> employees = new List<BaseEmployee>();

        string[] input = Console.ReadLine().Split();
        while (input[0] != "End")
        {
            switch (input[0])
            {
                case "Job":
                    Job job = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name == input[3]));

                    job.JobDone += job.OnJobDone;
                    jobs.Add(job);
                    break;

                case "StandartEmployee":
                    employees.Add(new StandartEmployee(input[1]));
                    break;

                case "PartTimeEmployee":
                    employees.Add(new PartTimeEmployee(input[1]));
                    break;

                case "Pass":
                    foreach (var j in jobs)
                    {
                        j.Update();
                    }
                    break;

                case "Status":
                    foreach (var j in jobs)
                    {
                        if (j.IsDone == false)
                        {
                            Console.WriteLine(j.ToString());
                        }
                    }
                    break;
            }

            input = Console.ReadLine().Split();
        }
    }
}

