namespace _10._AppliedArithmetics
{
    using System;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = numbers.Select(x => ++x).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => --x).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x * 2).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
