using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        Shape rectangle = new Rectangle(2.1, 4.2);
        Shape circle = new Circle(3.2);

        var listOfShapes = new List<Shape>();
        listOfShapes.Add(rectangle);
        listOfShapes.Add(circle);

        foreach (var currentShape in listOfShapes)
        {
            Console.WriteLine($"{currentShape.CalculatePerimeter():f2}");
            Console.WriteLine($"{currentShape.CalculateArea():f2}");
            Console.WriteLine($"{currentShape.Draw():f2}");
        }

    }
}

