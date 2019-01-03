using System;

public class Citizen : IIdentity, IBirthday, IBuyer
{
    private int food = 0;

    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthday { get; set; }
    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

