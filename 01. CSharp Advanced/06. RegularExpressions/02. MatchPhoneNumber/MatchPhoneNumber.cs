using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^(\+359)( |\-)2\2\d{3}\2(\d{4})$";

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
