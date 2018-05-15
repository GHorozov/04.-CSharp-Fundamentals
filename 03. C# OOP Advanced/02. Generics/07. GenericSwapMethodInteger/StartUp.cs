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

        var box = new Box<int>();

        for (int i = 0; i < n; i++)
        {
            box.AddElement(int.Parse(Console.ReadLine()));
        }

        var indexes = Console.ReadLine().Split(' ');

        box.Swap(int.Parse(indexes[0]), int.Parse(indexes[1]));

        Console.WriteLine(box.ToString());
    }
}

