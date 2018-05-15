using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class JobsEventArgs : EventArgs
{
    public JobsEventArgs(Job job)
    {
        this.Job = job;

    }

    public Job Job { get; set; }
}

