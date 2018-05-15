using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[InfoAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class Startup
{
    public static void Main(string[] args)
    {
        var inputLine = string.Empty;

        var attr = (InfoAttribute)typeof(Startup).GetCustomAttributes(true).FirstOrDefault();

        while (!(inputLine = Console.ReadLine()).Equals("END"))
        {
            Console.WriteLine(attr.PrintInfo(inputLine));
        }
    }
}

