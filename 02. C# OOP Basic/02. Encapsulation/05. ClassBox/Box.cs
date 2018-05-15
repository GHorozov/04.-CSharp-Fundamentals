using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length,double width,double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public void GetSurfaceArea(double lenhth, double width, double height)
    {
        var result = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
        Console.WriteLine($"Surface Area - {result:f2}");
    }
    public void GetLiteralSurface(double lenhth, double width, double height)
    {
        var result = 2 * this.length * this.height + 2 * this.width * this.height;
        Console.WriteLine($"Lateral Surface Area - {result:f2}");
    }
    public void GetVolume(double lenhth, double width, double height)
    {
        var result = this.length * this.width * this.height;
        Console.WriteLine($"Volume - {result:f2}");
    }
}

