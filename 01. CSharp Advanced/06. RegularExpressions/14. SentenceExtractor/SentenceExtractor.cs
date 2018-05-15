using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SentenceExtractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine();

            var sentances = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var pattern = @"[\w ]+\b" + word + @"\b[\w ]+[!.?]"; //Match all to is and all to end of sentance. Match only these that right one.
            var matches = Regex.Matches(input, pattern);

            foreach (var sentance in matches)
            {
                Console.WriteLine(sentance.ToString().TrimStart());
            }
        }
    }
}
