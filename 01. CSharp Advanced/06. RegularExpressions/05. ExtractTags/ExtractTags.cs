using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractTags
{
    class ExtractTags
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            while (text != "END")
            {
                var matches = Regex.Matches(text, @"<.+?>");
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
                
                text = Console.ReadLine();
            }
           
        }
    }
}
