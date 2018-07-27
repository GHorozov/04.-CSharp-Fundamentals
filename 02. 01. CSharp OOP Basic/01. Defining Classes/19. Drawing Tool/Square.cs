using System;
using System.Text;

public class Square : Figure
{
    public Square(int lenght)
    {
        this.Length = lenght;
    }

    public override void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', this.Length));

        for (int i = 2; i < this.Length; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', this.Length));
        }

        Console.WriteLine("|{0}|", new string('-', this.Length));
    }
}

