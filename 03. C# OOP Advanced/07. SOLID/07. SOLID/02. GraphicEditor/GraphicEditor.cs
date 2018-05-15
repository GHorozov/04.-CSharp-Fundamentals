namespace _02.Graphic_Editor
{
    using System;

    public class GraphicEditor
    {
        private IShape shape;

        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.PrintFugure());
        }
    }
}

