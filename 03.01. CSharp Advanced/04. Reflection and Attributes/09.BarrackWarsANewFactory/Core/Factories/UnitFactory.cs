using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        var type = Type.GetType(unitType);
        var newUnit = (IUnit)Activator.CreateInstance(type);

        return newUnit;
    }
}

