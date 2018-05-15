using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            var number = int.Parse(Console.ReadLine());

            Func<int,int,bool> filter = (n,d) => n % d == 0;
            CheckAndPrint(input, number, filter);
        }

        private static void CheckAndPrint(int[] input, int number, Func<int,int,bool> filter)
        {
            var result = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentNumber = input[i];
                if(!filter(currentNumber, number))
                {
                    result.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
