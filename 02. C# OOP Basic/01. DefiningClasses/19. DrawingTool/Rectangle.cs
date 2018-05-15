﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rectangle
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; set; }
    public int Height { get; set; }

    public void Draw()
    {
        for (int i = 0; i < this.Height; i++)
        {
            if (i == 0 || i == this.Height - 1)
            {
                Console.WriteLine("|" + new string('-', this.Width) + "|");
            }
            else
            {
                Console.WriteLine("|" + new string(' ', this.Width) + "|");
            }
        }
    }
}