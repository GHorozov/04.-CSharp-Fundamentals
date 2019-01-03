using System;

public class Rebel : IBuyer
{
    private int food = 0;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public int Food { get; set; }
    public string Group { get; set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

