using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        PrintNamesWithTypeCasting();
    }
    private static void PrintNamesWithTypeCasting()
    {
        var name = Console.ReadLine().Split();

        while (name[0] != "End")
        {
            var human = new Citizen(name[0]);
            Console.WriteLine(((IPerson)human).GetName());
            Console.WriteLine(((IResident)human).GetName());

            name = Console.ReadLine().Split();
        }
    }

    //private static void PrintNamesAsDifferentInterfaces()
    //{
    //    var name = Console.ReadLine().Split();

    //    while (name[0] != "End")
    //    {
    //        IPerson person = new Citizen(name[0]);
    //        Console.WriteLine(person.GetName());

    //        IResident resident = new Citizen(name[0]);
    //        Console.WriteLine(resident.GetName());

    //        name = Console.ReadLine().Split();
    //    }
    //}
}
