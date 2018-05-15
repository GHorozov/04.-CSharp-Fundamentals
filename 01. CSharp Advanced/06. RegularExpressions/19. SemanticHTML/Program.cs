using System;
using System.Text.RegularExpressions;

namespace _11.Semantic_HTML
{
    public class SemanticHTML
    {
        public static void Main()
        {
            var openingPattern = @"<div\s*(.*)(?:id|class)\s*=\s*""(.*?)""(.*?)>";
            var closingPattern = @"<\/div>\s*<!--\s*(.*?)\s*-->";
            var line = Console.ReadLine();

            while (line != "END")
            {
                var openingTag = Regex.Match(line, openingPattern);
                var closingTag = Regex.Match(line, closingPattern);
                if (openingTag.Success)
                {
                    line = $"{openingTag.Groups[2].Value} {openingTag.Groups[1].Value} {openingTag.Groups[3].Value}".Trim();
                    line = "<" + Regex.Replace(line, @"\s+", " ") + ">";
                }

                if (closingTag.Success)
                {
                    line = $"</{closingTag.Groups[1].Value}>";
                }

                Console.WriteLine(line);
                line = Console.ReadLine();
            }
        }
    }
}