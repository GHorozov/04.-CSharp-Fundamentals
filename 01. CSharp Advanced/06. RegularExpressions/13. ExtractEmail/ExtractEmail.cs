using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmail
{
    class ExtractEmail
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = @"([\w-.]+\@[A-Za-z-]+)(\.[A-Za-z-]+)+";
           
            var matches = Regex.Matches(text, pattern);

            foreach (var match in matches)
            {
                var matchString = match.ToString();
                if (!(matchString.StartsWith("-") || matchString.StartsWith(".")
                    || matchString.StartsWith("_") || matchString.EndsWith("-")
                    || matchString.EndsWith(".") || matchString.EndsWith("_")))
                {
                Console.WriteLine(matchString);
                }
            }
        }
    }
}
