using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var box = new Box<string>();

        for (int i = 0; i < n; i++)
        {
            box.AddElement(Console.ReadLine());
        }

        Console.WriteLine(box.CompareElements(Console.ReadLine()));
    }
}

