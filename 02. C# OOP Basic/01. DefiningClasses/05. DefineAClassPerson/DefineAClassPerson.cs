using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class DefineAClassPerson
{
    static void Main(string[] args)
    {
        var person1 = new Person("Pesho", 20);
        var person2 = new Person("Gosho", 21);
        var person3 = new Person("Stamat", 22);

        Type personType = typeof(Person);
        FieldInfo[] field = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(field.Length);
    }
}

