namespace _13._Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomComparator
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Array.Sort(numbers, (x, y) =>
            {
                //first criteria odd or even
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                //second criteria smaller or bigger number
                if (x > y)
                {
                    return 1;
                }
                if (x < y)
                {
                    return -1;
                }

                return 0;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
