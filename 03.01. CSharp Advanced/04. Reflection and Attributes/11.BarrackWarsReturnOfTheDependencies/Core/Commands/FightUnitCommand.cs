using System;
using System.Collections.Generic;
using System.Text;

public class FightUnitCommand : Command
{
    public FightUnitCommand(string[] data) 
        : base(data)
    {
    }

    public override string Execute()
    {
        Environment.Exit(0);

        return "";
    }
}

