using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var gE = new GraphicEditor();
            var circle = new Circle();
            var rectangle = new Rectangle();
            var square = new Square();
            var polygon = new Polygon();

            gE.DrawShape(circle);
            gE.DrawShape(rectangle);
            gE.DrawShape(square);
            gE.DrawShape(polygon);
        }
    }
}
