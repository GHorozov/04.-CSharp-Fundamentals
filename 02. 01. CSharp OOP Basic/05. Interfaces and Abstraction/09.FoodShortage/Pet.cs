public class Pet : IBirthday
{
    public Pet(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }
}

