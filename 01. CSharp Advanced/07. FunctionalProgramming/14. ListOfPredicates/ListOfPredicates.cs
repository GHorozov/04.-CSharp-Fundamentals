using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int, int, bool> filter = (n, d) => n % d == 0;
            SelectAndPrint(input, numbers, filter);

        }

        private static void SelectAndPrint(int input, int[] numbers, Func<int, int, bool> filter)
        {
            var list = new List<int>();
            for (int i = 1; i <= input; i++)
            {
                var isPassed = true;
                foreach (var number in numbers)
                {
                    if(!filter(i, number))
                    {
                        isPassed = false;
                        break;
                    }
                }

                if (isPassed)
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
