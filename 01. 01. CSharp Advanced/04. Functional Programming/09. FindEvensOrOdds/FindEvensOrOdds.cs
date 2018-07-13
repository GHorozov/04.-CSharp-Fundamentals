namespace _09._FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var lowerBound = numbers[0];
            var upperBound = numbers[1];

            var command = Console.ReadLine();

            var isOddOrEven = IsOddOrEven(command);
            var result = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (isOddOrEven(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static Predicate<int> IsOddOrEven(string command)
        {
            if(command == "odd")
            {
                return x => x % 2 != 0;
            }
            else
            {
                return x => x % 2 == 0;
            }
        }
    }
}
