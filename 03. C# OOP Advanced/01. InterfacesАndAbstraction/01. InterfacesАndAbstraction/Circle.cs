using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Circle : IDrawable
{
    private int radius;
    public Circle(int radius)
    {
        this.Radius = radius;
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
        double inR = this.Radius - 0.4;
        double outR = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; --y)
        {
            for (double x = -this.Radius; x < outR; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= inR * inR && value < outR * outR)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}

