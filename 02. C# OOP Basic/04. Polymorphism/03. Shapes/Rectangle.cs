using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rectangle : Shape
{
    private double height;
    private double weight;

    public Rectangle(double height, double weight)
    {
        this.Height = height;
        this.Weight = weight;
    }
    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public override double CalculatePerimeter()
    {
        return 2 * this.Height + 2 * this.Weight;
    }

    public override double CalculateArea()
    {
        return this.Height * this.Weight;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

