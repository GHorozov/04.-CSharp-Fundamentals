namespace _14._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = GetResult(dividers, n);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> GetResult(List<int> dividers, int n)
        {
            var numbersInRange = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbersInRange.Add(i);
            }

            Func<int, int, bool> filter = (x, y) => x % y == 0;

            var result = new List<int>();
            foreach (var number in numbersInRange)
            {
                var isPass = true;
                foreach (var divider in dividers)
                {
                    if(!filter(number, divider))
                    {
                        isPass = false;break;
                    }
                }

                if (isPass)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
