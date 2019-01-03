public class Box
{
    private double lenght;
    private double width;
    private double height;

    public Box(double lenght, double width,double height)
    {
        this.lenght = lenght;
        this.width = width;
        this.height = height;
    }

    public double GetSurfaceArea()
    {
        return (2 * lenght * width) + (2 * lenght * height) + (2 * width * height);
    }

    public double GetLateralSurfaceArea()
    {
        return (2 * lenght * height) + (2 * width * height);
    }

    public double GetVolume()
    {
        return lenght * width * height;
    }
}

