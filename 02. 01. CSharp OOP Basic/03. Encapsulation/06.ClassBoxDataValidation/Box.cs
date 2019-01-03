using System;

public class Box
{
    private double length;
    private double width;
    private double height;
    
    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            ValidateSide(value, "Length");
            this.length = value;
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            ValidateSide(value, "Width");
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            ValidateSide(value, "Height");
            this.height = value;
        }
    }

    private void ValidateSide(double side, string sideName)
    {
        if (side <= 0)
        {
            throw new ArgumentException(sideName + " cannot be zero or negative.");
        }
    }

    public double GetSurfaceArea()
    {
        return (2 * length * width) + (2 * length * height) + (2 * width * height);
    }

    public double GetLateralSurfaceArea()
    {
        return (2 * length * height) + (2 * width * height);
    }

    public double GetVolume()
    {
        return length * width * height;
    }
}

