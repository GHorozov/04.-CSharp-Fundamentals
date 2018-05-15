using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Robot : ICitizen
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Id { get; }
    public string Model { get; }
}

