namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
