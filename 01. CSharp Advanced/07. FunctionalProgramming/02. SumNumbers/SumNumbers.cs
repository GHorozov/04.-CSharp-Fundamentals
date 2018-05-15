using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);

            Console.WriteLine(input
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Count());

            Console.WriteLine(input
                .Split(new[] {", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Sum());
        }
    }
}
