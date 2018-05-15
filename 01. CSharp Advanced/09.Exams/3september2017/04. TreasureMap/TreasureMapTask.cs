using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.TreasureMap
{
    class TreasureMapTask
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var matches = Regex.Matches(line, @"[#].*((?<![0-9A-Za-z])[A-Za-z]{4}(?![0-9A-Za-z])).*(\d{3})-(\d{4}|\d{6})[!]|[!].*((?<![0-9A-Za-z])[A-Za-z]{4}(?![0-9A-Za-z])).*(\d{3})-(\d{4}|\d{6})[#]");

                foreach (Match match in matches)
                {
                    Console.WriteLine($"Go to str. {match.Groups[1].Value} {match.Groups[2].Value.ToString()}. Secret pass: {match.Groups[3].Value.ToString()}.");
                }
            }
        }
    }
}
