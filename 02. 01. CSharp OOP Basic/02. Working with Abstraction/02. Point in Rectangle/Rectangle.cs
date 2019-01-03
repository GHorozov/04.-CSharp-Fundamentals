public class Rectangle
{

    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        this.TopX = topX;
        this.TopY = topY;
        this.BottomX = bottomX;
        this.BottomY = bottomY;
    }

    public int TopX { get; set; }
    public int TopY { get; set; }
    public int BottomX { get; set; }
    public int BottomY { get; set; }

    public bool Contains(Point point)
    {
        return point.X >= TopX && point.X <= BottomX && point.Y >= TopY && point.Y <= BottomY;
    }
}
