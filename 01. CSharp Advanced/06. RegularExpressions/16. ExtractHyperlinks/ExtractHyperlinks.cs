using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();
            
            while(input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var text = sb.ToString();

            var pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            var matches = Regex.Matches(text, pattern);

            foreach (Match hlink in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (hlink.Groups[i].Length > 0) //if there is anything in group print it.
                    {
                        Console.WriteLine(hlink.Groups[i].Value);
                    }      
                }            
            }
        }
    }
}
