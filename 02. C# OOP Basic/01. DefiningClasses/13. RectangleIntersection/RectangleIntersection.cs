using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RectangleIntersection
{
    static void Main(string[] args)
    {
        var n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var numberOfRectangles = n[0];
        var intersectionCheckNumber = n[1];

        var rect = new Dictionary<string, Rectangle>();

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var line = Console.ReadLine().Split(' ');
            var name = line[0];
            var width = double.Parse(line[1]);
            var height = double.Parse(line[2]);
            var x = double.Parse(line[3]);
            var y = double.Parse(line[4]);

            if (!rect.ContainsKey(name))
            {
                rect.Add(name, new Rectangle(name, width, height, x, y));
            }

            rect[name] = new Rectangle(name, width, height, x, y);
        }

        for (int i = 0; i < intersectionCheckNumber; i++)
        {
            var currentRectangles = Console.ReadLine().Split(' ');
            var first = currentRectangles[0];
            var second = currentRectangles[1];

            Console.WriteLine(rect[first].IsIntersect(rect[second]) ? "true" : "false");
        }
    }
}

