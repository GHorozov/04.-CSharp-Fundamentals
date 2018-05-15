using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ');

        var lightList = new List<Light>();

        foreach (var item in input)
        {
            lightList.Add(new Light(item));
        }
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            lightList.ForEach(x => x.Change());

            Console.WriteLine(string.Join(" ", lightList));
        }
    }
}
