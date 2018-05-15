using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractIntegerNumbers
{
    class ExtractIntegerNumbers
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, @"[0-9]+");

            foreach(Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
