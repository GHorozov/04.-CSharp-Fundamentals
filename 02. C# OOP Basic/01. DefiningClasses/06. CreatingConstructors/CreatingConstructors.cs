using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class CreatingConstructors
{
    static void Main(string[] args)
    {
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        var firstPerson = new Person(name, age);

        Type personType = typeof(Person);
        ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
        ConstructorInfo ageCtor = personType.GetConstructor(new Type[] {typeof(int)});
        ConstructorInfo nameAgeCtor = personType.GetConstructor(new Type[] { typeof(string), typeof(int) });

        bool swapped = false;
        if(nameAgeCtor == null)
        {
            nameAgeCtor = personType.GetConstructor(new Type[] { typeof(string), typeof(int) });
            swapped = true;
        }

        Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        Person personWithAge= (Person)ageCtor.Invoke(new object[] {age});
        Person personWithAgeName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }): (Person)nameAgeCtor.Invoke(new object[] { name, age });

        Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
        Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
        Console.WriteLine("{0} {1}", personWithAgeName.name, personWithAgeName.age);
    }
}

