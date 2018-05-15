﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FightCommand : Command
{
    public FightCommand(string[] data) : base(data)
    {
    }

    public override string Execute()
    {
        Environment.Exit(0);
        return string.Empty;
    }
}
