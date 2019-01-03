using System;

public class Rectangle :IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            this.width = value;
        }
    }
    public int Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            this.height = value;
        }
    }

    public void Draw()
    {
        DrawTopBottom();
        DrawCenter();
        DrawTopBottom();
    }

    private void DrawCenter()
    {
        for (int i = 0; i < height-2; i++)
        {
            Console.Write("*");
            Console.Write(new string(' ',width-2));
            Console.WriteLine("*");
        }
    }

    private void DrawTopBottom()
    {
        Console.WriteLine(new string('*', width));
    }
}
