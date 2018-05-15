﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class JobsList : List<Job>
{
    public void OnJobDone(object sender, JobsEventArgs e)
    {
        this.Remove(e.Job);
    }
}

