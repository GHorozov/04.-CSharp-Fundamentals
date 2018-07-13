namespace _08._CustomMinFunction
{
    using System;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(numbers.Min());
        }
    }
}
