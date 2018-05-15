using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^([A-Z]\w+) ([A-Z]\w+)$";

            while (input != "end")
            {
                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }

        }
    }
}
