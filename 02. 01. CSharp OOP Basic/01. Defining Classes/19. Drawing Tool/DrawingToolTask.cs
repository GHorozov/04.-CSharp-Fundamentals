using System;

class DrawingToolTask
{
    static void Main(string[] args)
    {
        var type = Console.ReadLine().Trim();
        var drawingTool = new DrawingTool();
        var lenght = int.Parse(Console.ReadLine());
        Figure figure;

        if (type == "Square")
        {
            figure = new Square(lenght);
        }
        else
        {
            var width = int.Parse(Console.ReadLine());
            figure = new Rectangle(lenght, width);
        }

        drawingTool.Figure = figure;
        drawingTool.Figure.Draw();
    }
}

