using System;
using System.Collections.Generic;
using System.Text;

public class GemFactory :IGemFactory
{
    public IGem CreateGem(string[] data)
    {
        var inputGem = data[3].Split(" ");
        var clarity = inputGem[0];
        var gemType = Type.GetType(inputGem[1]);
        var gem = (IGem)Activator.CreateInstance(gemType, new object[] { clarity });

        return gem;
    }
}

