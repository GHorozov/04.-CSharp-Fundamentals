using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NonDigitCount
{
    class NonDigitCount
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, @"[^0123456789]");

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
