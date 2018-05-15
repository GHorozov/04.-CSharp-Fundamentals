using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Nation
{
    private List<Bender> bendersList;

    public Nation()
    {
        this.bendersList = new List<Bender>();
    }

    public List<Bender> BendersList
    {
        get
        {
            return this.bendersList;
        }
        set
        {
            this.bendersList = value;
        }
    }
}

