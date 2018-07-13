namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    class AddVAT
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x) * 1.2)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
                
        }
    }
}
