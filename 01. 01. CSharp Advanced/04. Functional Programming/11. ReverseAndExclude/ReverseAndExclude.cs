namespace _11._ReverseAndExclude
{
    using System;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers.Where(x => x % n != 0).Reverse()));
        }
    }
}
