﻿namespace _05.FerrariTask
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            ICar car = new Ferrari(name);
            Console.WriteLine(car);
        }
    }
}
