using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VowelCount
{
    class VowelCount
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var matches = Regex.Matches(text, @"[AEIOUYaeiouy]");

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
