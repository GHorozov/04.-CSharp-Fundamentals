using System;

class DefineAClassPerson
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.Name = "Ana";
        person.Age = 16;

        Person person1 = new Person("Maria", 18);
    }
}

