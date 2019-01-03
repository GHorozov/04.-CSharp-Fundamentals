using System;
using System.Collections.Generic;
using System.Text;

public interface ICommandInterpreter
{
    IExecutable InterpretCommand(string[] data);
}

