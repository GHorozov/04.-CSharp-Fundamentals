using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var match = new Regex(@"(.)\1+"); //In first group($1) match first symbol (.) and than OUTSIDE first group match all symbol like first matched. Again match next symbol and add it to first group, match if there are any other like this symbol and so on until end of a string.   
            var result = match.Replace(input, "$1"); //Replace input string with all that is in first group($1).

            Console.WriteLine(result);
        }
    }
}
