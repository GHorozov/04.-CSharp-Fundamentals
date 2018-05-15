using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var box = new Box<string>();
        while (input != "END")
        {
            var line = input.Split(' ');

            switch (line[0])
            {
                case "Add":
                    var element = line[1];
                    box.AddElement(element);
                    break;

                case "Remove":
                    var index = int.Parse(line[1]);
                    box.Remove(index);
                    break;

                case "Contains":
                    element = line[1];
                    Console.WriteLine(box.Contains(element));
                    break;

                case "Sort":
                    box.Sort();
                    break;

                case "Swap":
                    var first = int.Parse(line[1]);
                    var second = int.Parse(line[2]);
                    box.Swap(first, second);
                    break;

                case "Greater":
                    element = line[1];
                    Console.WriteLine(box.Greater(element));
                    break;

                case "Max":
                    Console.WriteLine(box.Max());
                    break;

                case "Min":
                    Console.WriteLine(box.Min());
                    break;
                case "Print":
                    Console.WriteLine(box.ToString());
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
