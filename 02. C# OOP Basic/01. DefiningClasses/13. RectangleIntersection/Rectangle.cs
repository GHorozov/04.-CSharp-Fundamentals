using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = Math.Abs(width);
        this.height = Math.Abs(height);
        this.x = x;
        this.y = y;
    }

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }
    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }
    public double X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public double Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public bool IsIntersect(Rectangle rectangle)
    {
        return rectangle.X + rectangle.Width >= this.x &&
                rectangle.X <= this.x + this.width &&
                rectangle.Y >= this.y - this.height &&
                rectangle.Y - rectangle.Height <= this.y;
    }

}

