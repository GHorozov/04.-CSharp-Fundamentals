namespace _08.Froggy
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(new string[] { " ", ","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake<int>(inputNumbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
