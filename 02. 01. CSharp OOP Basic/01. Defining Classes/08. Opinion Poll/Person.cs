class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public bool IsOlderBy30(Person person)
    {
        return person.age > 30;
    }
}

