using System;

public class Rectangle : Figure
{
    public Rectangle(int lenght, int width)
    {
        this.Length = lenght;
        this.Width = width;
    }

    public override void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', this.Length));

        for (int i = 2; i < this.Width; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', this.Length));
        }

        Console.WriteLine("|{0}|", new string('-', this.Length));
    }
}

