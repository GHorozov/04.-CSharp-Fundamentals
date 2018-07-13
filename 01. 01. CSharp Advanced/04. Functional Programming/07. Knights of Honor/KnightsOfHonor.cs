namespace _07._Knights_of_Honor
{
    using System;
    using System.Linq;

    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => "Sir " + x)
                 .ToList();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
