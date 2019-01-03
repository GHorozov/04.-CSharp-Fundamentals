using System;

public class Circle :IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public int Radius
    {
        get
        {
            return this.radius;
        }
        private set
        {
            this.radius = value;
        }
    }

    public void Draw()
    {
        getTopBottomLine();
        getCircleTop();
        getCircleBottom();
        getTopBottomLine();
    }

    private void getCircleBottom()
    {
        var count = 0;
        var counter = 2*(radius-2);
        for (int i = 0; i < radius - 1; i++)
        {
            Console.Write(new string(' ', count++) + "**");
            Console.Write(new string(' ', ((2 * radius) + 1) + counter));
            Console.WriteLine("**");
            counter -= 2;
        }
    }

    private void getCircleTop()
    {
        var count = 0;
        var counter = radius-2;
        for (int i = radius-1; i >= 0; i--)
        {
            if (i > 0)
            {
                Console.Write(new string(' ', counter--) + "**");
            }
            else
            {
                Console.Write("*");
            }
            Console.Write(new string(' ', (2 * radius) + 1 + (2*count++)));
            if (i > 0)
            {
                Console.WriteLine("**");
            }
            else
            {
                Console.WriteLine("*");
            }
        }
    }

    private void getTopBottomLine()
    {
        var strLeftRight = new string(' ', radius);
        var center = new string('*', (2 * radius) + 1);
        Console.WriteLine(strLeftRight + center + strLeftRight);
    }
}

