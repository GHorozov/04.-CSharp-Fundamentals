using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var phone = new Smartphone("Smartphone");
        TestPhone(phone);      
    }

    private static void TestPhone(ISmartphone phone)
    {
        var numbersToCall = Console.ReadLine().Split();

        foreach (var number in numbersToCall)
        {
            Console.WriteLine(phone.Call(number));
        }

        var sitesToBrowse = Console.ReadLine().Split();

        foreach (var site in sitesToBrowse)
        {
            Console.WriteLine(phone.Browse(site));
        }
    }
}