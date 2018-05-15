using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CorDraw
{
    public Rectangle Rectangle { get; set; }
    public Square Square { get; set; }

    public CorDraw(Rectangle rectangle)
    {
        this.Rectangle = rectangle;
    }

    public CorDraw(Square square)
    {
        this.Square = square;
    }
}

