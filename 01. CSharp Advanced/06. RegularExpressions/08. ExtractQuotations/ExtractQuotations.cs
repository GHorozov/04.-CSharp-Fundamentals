using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractQuotations
{
    class ExtractQuotations
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var matches = Regex.Matches(text, "('|\")(.+?)\\1");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
