using System;

public class Ferrari : ICar
{
    private string name;
    private readonly string model = "488-Spider";

    public Ferrari(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string PushBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.model}/{PushBrakes()}/{PushGasPedal()}/{this.Name}";
    }
}

