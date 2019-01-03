namespace _03.Shapes
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2.0, 3.0);
            Shape circle = new Circle(3);

            var list = new List<Shape>();
            list.Add(rectangle);
            list.Add(circle);

            foreach (var figure in list)
            {
                Console.WriteLine(figure.Draw());
                Console.WriteLine(figure.CalculatePerimeter());
                Console.WriteLine(figure.CalculateArea());
            }
        }
    }
}
