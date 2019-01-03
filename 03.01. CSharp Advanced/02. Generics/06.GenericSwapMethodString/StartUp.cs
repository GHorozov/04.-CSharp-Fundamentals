namespace _06.GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var element = Console.ReadLine();
                box.AddItem(element);
            }
            var indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var index1 = indexes[0];
            var index2 = indexes[1];

            box.SwapElements<string>(index1, index2);

            Console.WriteLine(box);
        }
    }
}
