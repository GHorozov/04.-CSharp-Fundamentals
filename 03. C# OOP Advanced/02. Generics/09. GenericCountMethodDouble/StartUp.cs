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

        Box<double> box = new Box<double>();

        for (int i = 0; i < n; i++)
        {
            box.AddElement(double.Parse(Console.ReadLine()));
        }

        var element = double.Parse(Console.ReadLine());
        Console.WriteLine(box.CompareElements(element));
    }
}

