public class Rectangle
{
    public string id;
    public decimal width;
    public decimal height;
    public decimal x;
    public decimal y;

    public Rectangle(string id, decimal width, decimal height, decimal x, decimal y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }

    public bool IsIntersect(Rectangle secondRectangle)
    {
        return (secondRectangle.x + secondRectangle.width >= this.x) && (secondRectangle.x <= this.x + this.width) &&
               (secondRectangle.y >= this.y - this.height) && (secondRectangle.y - secondRectangle.height <= this.y);
    }
}

