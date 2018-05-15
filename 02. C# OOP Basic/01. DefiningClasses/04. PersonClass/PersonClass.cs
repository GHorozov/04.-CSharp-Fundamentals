using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PersonClass
{
    static void Main(string[] args)
    {
        var person = new Person("Georgi", 30);
        Console.WriteLine(person.GetBalance());  
    }
}

