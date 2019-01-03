using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var rectangle = new Rectangle(input[0], input[1], input[2], input[3]);
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var currentPoint = new Point(line[0], line[1]);

            Console.WriteLine(rectangle.Contains(currentPoint));
        }
    }
}

