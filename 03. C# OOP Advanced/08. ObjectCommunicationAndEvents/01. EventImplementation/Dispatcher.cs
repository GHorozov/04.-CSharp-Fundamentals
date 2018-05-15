using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

public class Dispatcher
{
    public event NameChangeEventHandler NameChange;

    private string name;


    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }



    public void OnNameChange(NameChangeEventArgs e)
    {
        if(NameChange != null)
        {
            NameChange(this, e);
        }
    }
}

