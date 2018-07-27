using System;
using System.Collections.Generic;
using System.Linq;

class RectangleIntersection
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var n = int.Parse(input[0]);
        var m = int.Parse(input[1]);
        var list = new List<Rectangle>();
        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var id = lineParts[0];
            var width = decimal.Parse(lineParts[1]);
            var height = decimal.Parse(lineParts[2]);
            var x = decimal.Parse(lineParts[3]);
            var y = decimal.Parse(lineParts[4]);
            list.Add(new Rectangle(id, width, height, x, y));
        }

        for (int i = 0; i < m; i++)
        {
            var pairs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var firstRect = pairs[0];
            var secondRect = pairs[1];

            Console.WriteLine(list.FirstOrDefault(x => x.id == firstRect)
                .IsIntersect(list.FirstOrDefault(x => x.id == secondRect)).ToString().ToLower());
        }
    }
}

