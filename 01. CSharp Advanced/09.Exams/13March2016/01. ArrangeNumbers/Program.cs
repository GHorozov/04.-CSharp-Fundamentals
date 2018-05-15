using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ArrangeNumbers
{
    class Program
    {
        private static readonly string[] IntegersName = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = input.OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegersName[ch - '0'])));
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
