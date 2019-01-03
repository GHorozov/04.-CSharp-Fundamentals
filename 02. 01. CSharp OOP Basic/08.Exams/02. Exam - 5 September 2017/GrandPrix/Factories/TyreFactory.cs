using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> args)
    {
        var tyreType = args[0];
        var hardness = double.Parse(args[1]);

        switch (tyreType)
        {
            case "Ultrasoft":
                var grip = double.Parse(args[2]);
                return new UltrasoftTyre(hardness, grip);
            case "Hard":
                return new HardTyre(hardness);
            default:
                throw new InvalidOperationException();
        }
    }
}

