namespace _04.BubbleSort
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 3, 5, 4, 2, 1};
            var bubble = new Bubble(list);
            Console.WriteLine(string.Join(", ", bubble.Collection));
            bubble.BubbleSort();
            Console.WriteLine(string.Join(", ", bubble.Collection));
        }
    }
}
